using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ResumeMaker.Data;
using ResumeMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResumeMaker.Helpers;
using Microsoft.AspNetCore.Http;

namespace ResumeMaker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ResumeInfoContext _context;
        private readonly MvcOptions _mvcOptions;
        public List<ResumeInfo> ResumeInfos { get; set; }
        public int UserID { get; set; }

        public IndexModel(ResumeInfoContext context, IOptions<MvcOptions> mvcOptions)
        {
            _context = context;
            _mvcOptions = mvcOptions.Value;
        }

        public IActionResult OnPostEdit()
        {
            return RedirectToPage("/Edit");
        }
        public IActionResult OnGetAsync()
        {
            Console.WriteLine("SESSSSSSSSSION IDDD IS:::::::::::::::::" + SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "ID"));
            if (SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "ID") == -1 
                    || SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "ID") == 0)
                UserID = -1;
            else
            {
                ResumeInfos = _context.ResumeInfos.Where(e => e.UserID == SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "ID")).ToList();
                UserID = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, "ID");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/ResumeForm");
        }
     }
}
