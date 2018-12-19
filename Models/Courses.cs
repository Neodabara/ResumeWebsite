using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResumeWebsite.Models
{
    public class Courses
    {
        public int ID { get; set; }

        [Display(Name = "Course Name")] //sets the display name 
        [Required] //makes it a required field
        public string CourseName { get; set; }

        [Display(Name = "Course Number")] //sets the display name
        [Range(100, 999)] //sets the range of the acceptable numbers to 100 - 999
        [Required] // makes it a required field
        public int CourseNumber { get; set; }

       [Display(Name = "Course ID")] //sets the display name
       [StringLength(2)] // sets the acceptable length for the string entered to no more than 2 (IE CS is ok, C is ok, CSS is not)
       [Required] // makes it a required field
        public string CourseID { get; set; }
    }
}
