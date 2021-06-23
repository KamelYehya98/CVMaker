using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeMaker.Models;
using ResumeMaker.Helpers;
using ResumeMaker.Data;
using Microsoft.AspNetCore.Http;

namespace ResumeMaker.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        private ResumeInfoContext context;
        public string ErrorMessage { get; set; }

        public IndexModel(ResumeInfoContext _context)
        {
            context = _context;
        }
        public void OnGet()
        {
            
        }

        public void OnGetLogOut()
        {
            HttpContext.Session.Remove("ID");
        }

        public IActionResult OnPost()
        {
            var account = CheckCredentials();
            if (account == null)
                return Page();

            SessionHelper.SetObjectAsJson(HttpContext.Session, "ID", (int)account.UserID);
            return RedirectToPage("/Welcome");
        }

        public User CheckCredentials()
        {
            var account = context.Users.SingleOrDefault(e => e.UserName.Equals(user.UserName));
            if (account == null)
            {
                ErrorMessage = "Wrong Username";
                return null;
            }   
            if (!account.Password.Equals(user.Password))
            {
                ErrorMessage = "Wrong Password";
                return null;
            }
           
            return account;
        }
    }


}
