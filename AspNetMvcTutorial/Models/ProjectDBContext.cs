using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNetMvcTutorial.Models
{
    public class ProjectDBContext : DbContext
    {        
        DbSet<Subject> Subjects { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Project> Projects { get; set; }

        public ProjectDBContext() : base("ProjectDbContext") { }



    }
}