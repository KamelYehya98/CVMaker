﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResumeMaker.Data;
using ResumeMaker.Models;

namespace ResumeMaker.Pages.Resumes
{
    public class CreateModel : PageModel
    {
        private readonly ResumeMaker.Data.ResumeInfoContext _context;

        public CreateModel(ResumeMaker.Data.ResumeInfoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ResumeInfo ResumeInfo { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ResumeInfos.Add(ResumeInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
