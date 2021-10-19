using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeMaker.Data;
using ResumeMaker.Models;
using ResumeMaker.Helpers;

namespace ResumeMaker.Pages
{
    public class MyResumesModel : PageModel
    {
        private readonly ResumeInfoContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        [BindProperty(SupportsGet = true)]
        public int UserID { get; set; }

        public List<ResumeInfo> Resumes { get; set; }
        public MyResumesModel(ResumeInfoContext context, IWebHostEnvironment _webhost)
        {
            _context = context;
            webHostEnvironment = _webhost;
        }
        public void OnGet()
        {
            UserID = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "ID");
            Console.WriteLine("IN MY RESUMES USERID IS + RESUME ID IS::::::::::::" + UserID + "::::");
            Resumes = _context.ResumeInfos.Where(p => p.UserID == UserID).ToList();
            Console.WriteLine("NB OF RESUMES FOUND:::::" + Resumes.Count);
        }

        public IActionResult OnPostDetails(int resumeID)
        {
            return RedirectToPage($"/GenerateResume", new { id = resumeID });
        }

        public IActionResult OnPostEdit(int resumeID)
        {
            return RedirectToPage($"/ResumeForm", new { id = resumeID });
        }

        public IActionResult OnPostDelete(int resumeID)
        {
            return RedirectToPage($"/Delete", new { id = resumeID });
        }
    }


}
