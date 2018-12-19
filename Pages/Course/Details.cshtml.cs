using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResumeWebsite.Models;

//Premade Details model from the CRUD

namespace ResumeWebsite.Pages.Course
{
    public class DetailsModel : PageModel
    {
        private readonly ResumeWebsite.Models.ResumeWebsiteContext _context;

        public DetailsModel(ResumeWebsite.Models.ResumeWebsiteContext context)
        {
            _context = context;
        }

        public Courses Courses { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Courses = await _context.Courses.FirstOrDefaultAsync(m => m.ID == id);

            if (Courses == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
