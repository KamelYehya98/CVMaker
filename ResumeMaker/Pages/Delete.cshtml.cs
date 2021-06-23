using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResumeMaker.Data;
using ResumeMaker.Models;

namespace ResumeMaker.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ResumeInfoContext _context;

        public DeleteModel(ResumeInfoContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public ResumeInfo Info { get; set; }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        public void OnGet()
        {
            Info = _context.ResumeInfos.FirstOrDefault(m => m.ResumeInfoID == id);
        }
        public IActionResult OnPost()
        {
            var languages = _context.Languages.Where(e => e.ResumeInfoID == id).ToList();
            foreach(Language lang in languages)
            {
                _context.Languages.Remove(lang);
                _context.SaveChanges();
            }

            var skills = _context.Skills.Where(e => e.ResumeInfoID == id).ToList();
            foreach (Skill skill in skills)
            {
                _context.Skills.Remove(skill);
                _context.SaveChanges();
            }

            var exps = _context.Experiences.Where(e => e.ResumeInfoID == id).ToList();
            foreach (Experience exp in exps)
            {
                _context.Experiences.Remove(exp);
                _context.SaveChanges();
            }

            _context.ResumeInfos.Remove(_context.ResumeInfos.Find(id));
            _context.SaveChanges();
            return RedirectToPage("/Welcome");
        }
    }
}
