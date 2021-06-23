using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeMaker.Models;
using ResumeMaker.Helpers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NUglify.Html;
using System.Web;
using Microsoft.JSInterop;
using ServiceStack;
using Stripe;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace ResumeMaker.Pages
{
    public class ResumeFormModel : PageModel
    {
        private readonly Data.ResumeInfoContext _context;
        [BindProperty(SupportsGet = true)]
        public ResumeInfo Info { get; set; }
        private readonly IWebHostEnvironment webHostEnvironment;

        [BindProperty]
        public IFormFile Photo { get; set; }
        [BindProperty(SupportsGet = true)]
        public int UserID { get; set; }
        public ResumeFormModel(Data.ResumeInfoContext context, IWebHostEnvironment _webhost)
        {
            _context = context;
            webHostEnvironment = _webhost;
        }
        public IActionResult OnGet()
        {
            if (SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "ID") == -1)
                return RedirectToPage("/Index");

            UserID = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "ID");
            return Page();
        }

        public void OnGetEdit()
        {
            Info = SessionHelper.GetObjectFromJson<ResumeInfo>(HttpContext.Session, "Info");
        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            int counter;

            var languagesName = Request.Form["LanguageName"];
            var skillsName = Request.Form["SkillName"];
            var expTitle = Request.Form["ExperienceTitle"];
            var expText = Request.Form["ExperienceText"];

            Info.UserID = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "ID");
            _context.ResumeInfos.Add(Info);
            await _context.SaveChangesAsync();

            counter = 0;
            foreach (string str in languagesName)
            {
                while(counter <= 100)
                {
                    if (!Request.Form["LanguageValue" + counter.ToString()].IsEmpty())
                    {
                        var languageValue = Request.Form["LanguageValue" + counter.ToString()];
                        var lang = new Language(str, Int32.Parse(languageValue));
                        Info.GetLanguages().Add(lang);
                        _context.Languages.Add(lang);
                        await _context.SaveChangesAsync();
                        counter++;
                        break;
                    }
                    counter++;
                }
            }
            counter = 0;
            foreach (string str in skillsName)
            {
                while(counter <= 100)
                {
                    if (!Request.Form["SkillValue" + counter.ToString()].IsEmpty())
                    {
                        var skillValue = Request.Form["SkillValue" + counter.ToString()];
                        var skill = new Skill(str, Int32.Parse(skillValue));
                        Info.GetSkills().Add(skill);
                        _context.Skills.Add(skill);
                        await _context.SaveChangesAsync();
                        counter++;
                        break;
                    }
                    counter++;
                }
            }
               
            counter = 0;
            foreach (string str in expTitle)
            {
                var experience = new Experience(str, expText[counter++]);
                Info.GetExperiences().Add(experience);
                _context.Experiences.Add(experience);
                await _context.SaveChangesAsync();
            }
            
            if(Photo != null)
            {
                if(Info.Image != null)
                {
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath,
                        "images", Info.Image);
                    System.IO.File.Delete(filePath); 
                }
                Info.Image = ProcessUploadedFile();
            }

            var InfoResume = await _context.ResumeInfos.OrderByDescending(u => u.ResumeInfoID).FirstOrDefaultAsync();

            return RedirectToPage($"/GenerateResume", new { id = InfoResume.ResumeInfoID });
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if(Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using(var fileStram = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStram);
                }
            }
            return uniqueFileName;
        }
    }
}
