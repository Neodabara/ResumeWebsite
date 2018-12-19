using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResumeWebsite.Models;

namespace ResumeWebsite.Pages.Course
{
    public class IndexModel : PageModel
    {
        private readonly ResumeWebsite.Models.ResumeWebsiteContext _context;

        public IndexModel(ResumeWebsite.Models.ResumeWebsiteContext context)
        {
            _context = context;
        }

        public IList<Courses> Courses { get;set; } //A list of courses

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } //Search string for looking up courses 

        public SelectList CourseNumber { get; set; } // the course number lookup
        [BindProperty(SupportsGet = true)]
        public string CourseCode { get; set; } //The course code lookup

        public async Task OnGetAsync()
        {
            IQueryable<string> courseCodeQuery = from m in _context.Courses //Query  that searches for a specific courseID
                                                 orderby m.CourseID
                                                 select m.CourseID;

            var courses = from m in _context.Courses 
                          select m;
            if(!String.IsNullOrEmpty(SearchString))
            {
                courses = courses.Where(s => s.CourseName.Contains(SearchString)); //Finds any course where the course name matches the string entered
            }

            if (!String.IsNullOrEmpty(CourseCode))
            {
                courses = courses.Where(x => x.CourseID == CourseCode); //Finds any course that matches the course ID entered 
            }

            CourseNumber = new SelectList(await courseCodeQuery.Distinct().ToListAsync());
            Courses = await courses.ToListAsync();
        }
    }
}
