using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetMvcTutorial.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        private Int16 ID { get; set; }

        [Required(ErrorMessage = "Wymagane jest podanie nazwy kursu")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Wymagane jest przypisanie co najmniej jednego modułu do kursu")]
        public List<Module> CourseModules { get; set; }

        public Course(String course)
        {
            this.Name = course;
        }

        
        

        
    }
}