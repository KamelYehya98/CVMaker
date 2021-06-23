using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeMaker.Models;
using ResumeMaker.Helpers;
using Microsoft.AspNetCore.Hosting;
using DocumentFormat.OpenXml.Presentation;
using Microsoft.AspNetCore.Http;
using ResumeMaker.Data;

namespace ResumeMaker.Pages
{
    public class GenerateResumeModel : PageModel
    {
        private readonly ResumeInfoContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        [BindProperty(SupportsGet = true)]
        public ResumeInfo Info { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        public GenerateResumeModel(ResumeInfoContext context, IWebHostEnvironment _webhost)
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
            foreach (Language lang in languages)
                Info.GetLanguages().Add(lang);

            var skills = _context.Skills.Where(ln => ln.ResumeInfoID == id).Select(ln => new Skill(ln.Name, ln.Proficiency)).ToList();
            foreach (Skill skill in skills)
                Info.GetSkills().Add(skill);

            var exps = _context.Experiences.Where(ln => ln.ResumeInfoID == id).Select(ln => new Experience(ln.Name, ln.Text)).ToList();
            foreach (Experience exp in exps)
                Info.GetExperiences().Add(exp);

            return Page();
        }
    }
}
