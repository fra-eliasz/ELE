using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetMvcTutorial.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        private Int16 ID { set; get; }

        [Required]
        public String Name { set; get; }

        [Required]
        public List<Course> ProjectCourses { set; get; }

        public Project(String projName)
        {
            this.Name = projName;
        }

    }
}