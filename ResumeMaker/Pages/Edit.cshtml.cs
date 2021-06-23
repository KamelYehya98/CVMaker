using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NUglify.Html;
using ResumeMaker.Data;
using ResumeMaker.Helpers;
using ResumeMaker.Models;
using ServiceStack;
//using System.Windows.Forms;

namespace ResumeMaker.Pages
{
    public class EditModel : PageModel
    {
        private readonly ResumeInfoContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        [BindProperty(SupportsGet = true)]
        public ResumeInfo Info { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        public EditModel(ResumeInfoContext context, IWebHostEnvironment _webhost)
        {
            _context = context;
            webHostEnvironment = _webhost;
        }
        public IActionResult OnGet()
        {
            if (SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "ID") == -1)
                return RedirectToPage("/Index");
            Info = _context.ResumeInfos.FirstOrDefault(m => m.ResumeInfoID == id);
            var languages = _context.Languages.Where(ln => ln.ResumeInfoID == id).Select(ln => new Language(ln.Name, ln.Proficiency)).ToList();
            foreach(Language lang in languages)
                Info.GetLanguages().Add(lang);

            var skills = _context.Skills.Where(ln => ln.ResumeInfoID == id).Select(ln => new Skill(ln.Name, ln.Proficiency)).ToList();
            foreach (Skill skill in skills)
                Info.GetSkills().Add(skill);

            var exps = _context.Experiences.Where(ln => ln.ResumeInfoID == id).Select(ln => new Experience(ln.Name, ln.Text)).ToList();
            foreach (Experience exp in exps)
                Info.GetExperiences().Add(exp);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Update();
            UpdateLanguages();
            UpdateSkills();
            UpdateExperiences();
           
            return RedirectToPage("Welcome");
        }

        public void Update() 
        {
            Info.ResumeInfoID = id;
            Info.UserID = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "ID");
            if (Photo != null)
            {
                if(Info.Image != null)
                {
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", Info.Image);
                    System.IO.File.Delete(filePath);
                }
                Info.Image = ProcessUploadedFile();
            }
            
            var info = _context.ResumeInfos.Attach(Info);

            info.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateLanguages()
        {
            Info.Languages = new List<Language>();

            var vp = _context.Languages.Where(a => a.ResumeInfoID == id);
            _context.Languages.RemoveRange(vp);
            _context.SaveChanges();

            var languagesName = Request.Form["LanguageName"];
            int counter = 0;
            foreach (string str in languagesName)
            {
                while (counter <= 100)
                {
                    if (!Request.Form["LanguageValue" + counter.ToString()].IsEmpty())
                    {
                        var languageValue = Request.Form["LanguageValue" + counter.ToString()];
                        var lang = new Language(str, Int32.Parse(languageValue));
                        lang.ResumeInfoID = id;
                        Info.GetLanguages().Add(lang);
                        _context.Languages.Add(lang);
                        _context.SaveChanges();
                        counter++;
                        break;
                    }
                    counter++;
                }
            }
        }

        public void UpdateSkills()
        {
            Info.Skills = new List<Skill>();

            var vp = _context.Skills.Where(a => a.ResumeInfoID == id);
            _context.Skills.RemoveRange(vp);
            _context.SaveChanges();

            var skillsname = Request.Form["SkillName"];
            int counter = 0;
            foreach (string str in skillsname)
            {
                while (counter <= 100)
                {
                    if (!Request.Form["SkillValue" + counter.ToString()].IsEmpty())
                    {
                        var skillValue = Request.Form["SkillValue" + counter.ToString()];
                        var skill = new Skill(str, Int32.Parse(skillValue));
                        skill.ResumeInfoID = id;
                        Info.GetSkills().Add(skill);
                        _context.Skills.Add(skill);
                        _context.SaveChanges();
                        counter++;
                        break;
                    }
                    counter++;
                }
            }
        }

        public void UpdateExperiences()
        {
            Info.Experiences = new List<Experience>();

            var vp = _context.Experiences.Where(a => a.ResumeInfoID == id);
            _context.Experiences.RemoveRange(vp);
            _context.SaveChanges();

            var expTitle = Request.Form["ExperienceTitle"];
            var expText = Request.Form["ExperienceText"];
            int counter = 0;
            for (int i=0; i<expTitle.Count; i++)
            {
                var exp = new Experience(expTitle[i], expText[i]);
                exp.ResumeInfoID = id;
                Info.GetExperiences().Add(exp);
                _context.Experiences.Add(exp);
                _context.SaveChanges();
                counter++;
            }
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStram = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStram);
                }
            }
            return uniqueFileName;
        }

    }
}
