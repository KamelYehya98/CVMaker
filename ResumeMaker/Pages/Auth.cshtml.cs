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
using Microsoft.EntityFrameworkCore;


namespace ResumeMaker.Pages
{
    public class AuthModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }
        private ResumeInfoContext context;
        public string ErrorMessage { get; set; }
        [BindProperty(SupportsGet = true)]
        public long ResumeID { get; set; }
        public AuthModel(ResumeInfoContext _context)
        {
            context = _context;
        }
        public void OnGet()
        {
            Console.WriteLine("EL ID YAALI #AM BNIK EL DENE IS::::::::::::::::::::" + ResumeID);
       
            if (user != null)
            {
                user.Password = "";
                user.PasswordConfirm = "";
            }
        }

        public void OnGetLogOut()
        {
            HttpContext.Session.Remove("ID");
        }

        public IActionResult OnPostLogIn()
        {
            Console.WriteLine("Inside On Post Log In...................AND ID: " + ResumeID);
            var account = CheckCredentials();
            if (account == null)
                return Page();

            SessionHelper.SetObjectAsJson(HttpContext.Session, "ID", (int)account.UserID);
            if(ResumeID != 0)
            {
                var resume = context.ResumeInfos.SingleOrDefault(e => e.ResumeInfoID == ResumeID);
                resume.UserID = account.UserID;
                var info = context.ResumeInfos.Attach(resume);
                info.State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToPage($"/GenerateResume", new { id = ResumeID });
            }
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostSignUp()
        {
            if (user.UserName == null || user.Password == null || user.PasswordConfirm == null || user.Email == null)
            {
                ErrorMessage = "Empty Fields";
                Console.WriteLine("RETURNED PAAAGE.................");
                return Page();
            }
            Console.WriteLine("INSIDE ONSIGNUP HANDLER.............");
            List<string> names = context.Users.Select(e => e.UserName).ToList();
            foreach (string name in names)
            {
                if (name == user.UserName)
                {
                    ErrorMessage = "Username taken";
                    return Page();
                }
            }
            if (user.Password != user.PasswordConfirm)
            {
                ErrorMessage = "Passwords don't match";
                return Page();
            }
            else if (user.Password.Length < 8)
            {
                ErrorMessage = "Password should be at least 8 characters";
                return Page();
            }
            Console.WriteLine(user.Password + " : " + user.UserName);
            context.Users.Add(user);
            context.SaveChanges();
            var account = context.Users.SingleOrDefault(e => e.UserName.Equals(user.UserName));
            if (ResumeID != 0)
            {
                Console.WriteLine("INSIDE ON SIGNUP POST >>>>>>>> ID IS: " + ResumeID);
                var resume = context.ResumeInfos.SingleOrDefault(e => e.ResumeInfoID == ResumeID);
                resume.UserID = account.UserID;
                var info = context.ResumeInfos.Attach(resume);
                info.State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToPage($"/GenerateResume", new { id = ResumeID });
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "ID", (int)account.UserID);
            return RedirectToPage("/Index");
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

            Console.WriteLine("INSIDE CHECK CREDS:::::::::::::::::::::::ID IS: " + ResumeID);
           
            return account;
        }
    }


}
