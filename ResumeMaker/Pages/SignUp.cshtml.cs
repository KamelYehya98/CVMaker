using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeMaker.Models;
using ResumeMaker.Data;
using ResumeMaker.Helpers;

namespace ResumeMaker.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        private ResumeInfoContext context;
        public string ErrorMessage { get; set; }

        public SignUpModel(ResumeInfoContext _context)
        {
            context = _context;
        }

        public IActionResult OnPost()
        {
            if (User.UserName == null || User.Password == null || User.PasswordConfirm == null || User.Email == null)
            {
                ErrorMessage = "Empty Fields";
                return Page();
            }
            List<string> names = context.Users.Select(e => e.UserName).ToList();
            foreach(string name in names)
            {
                if(name == User.UserName)
                {
                    ErrorMessage = "Username taken";
                    return Page();
                }
            }
            if(User.Password != User.PasswordConfirm)
            {
                ErrorMessage = "Passwords don't match";
                return Page();
            }
            else if(User.Password.Length < 8)
            {
                ErrorMessage = "Password should be at least 8 characters";
                return Page();
            }
            Console.WriteLine(User.Password + " : " + User.UserName);
            context.Users.Add(User);
            context.SaveChanges();
            return RedirectToPage("Index");
        }
        public void OnGet()
        {
            SessionHelper.SetObjectAsJson(HttpContext.Session, "ID", -1);
            if(User != null)
            {
                User.Password = "";
                User.PasswordConfirm = "";
            }

        }
    }
}
