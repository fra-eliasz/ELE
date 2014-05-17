using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvcTutorial.Models
{
    public class SubjectBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        private Int16 ID { get; set; }

        [Required(ErrorMessage="Wymagane jest podanie nazwy tematu")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Wymagane jest przypisanie przynajmniej jednego materiału do tematu")]
        public List<MaterialBase> SubjectMaterials { get; set; }

        public SubjectBase(String subjectName)
        {
            this.Name = subjectName;
        }
        
    }
}