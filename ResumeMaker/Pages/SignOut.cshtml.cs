using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeMaker.Helpers;

namespace ResumeMaker.Pages
{
    public class SignOutModel : PageModel
    {
        public IActionResult OnGet()
        {
            SessionHelper.SetObjectAsJson(HttpContext.Session, "ID", -1);
            return RedirectToPage("Index");
        }
    }
}
