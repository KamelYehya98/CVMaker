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
    public class DetailsModel : PageModel
    {
        private readonly ResumeInfoContext _context;

        public DetailsModel(ResumeInfoContext context)
        {
            _context = context;
        }

        public ResumeInfo ResumeInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ResumeInfo = await _context.ResumeInfos.FirstOrDefaultAsync(m => m.ResumeInfoID == id);

            if (ResumeInfo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
