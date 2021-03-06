﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetMvcTutorial.Models
{
    public class Module
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public Int16 ID { get; set; }

        [Required(ErrorMessage = "Wymagane jest podanie numeru modułu")]
        public Int16 Number { get; set; }

        [Required(ErrorMessage = "Wymagane jest podanie nazwy modułu")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Wymagane jest przypisanie przynajmniej jednego tematu do modułu")]
        public List<SubjectBase> ModuleSubjects { get; set; }

        public Module(Int16 number, String name)
        {
            this.Number = number;
            this.Name = name;
        }

              

        
    }
}