using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResumeWebsite.Models;

//Premade Delete model from the CRUD

namespace ResumeWebsite.Pages.Course
{
    public class DeleteModel : PageModel
    {
        private readonly ResumeWebsite.Models.ResumeWebsiteContext _context;

        public DeleteModel(ResumeWebsite.Models.ResumeWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Courses = await _context.Courses.FindAsync(id);

            if (Courses != null)
            {
                _context.Courses.Remove(Courses);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
