using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ResumeWebsite.Models
{
    public class ResumeWebsiteContext : DbContext
    {
        public ResumeWebsiteContext (DbContextOptions<ResumeWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<ResumeWebsite.Models.Courses> Courses { get; set; }
    }
}
