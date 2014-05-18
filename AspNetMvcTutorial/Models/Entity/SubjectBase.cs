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
        public Int16 ID { get; set; }

        [Required(ErrorMessage = "Wymagane jest podanie numeru tematu")]
        public Int16 Number { get; set; }

        [Required(ErrorMessage="Wymagane jest podanie nazwy tematu")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Wymagane jest przypisanie przynajmniej jednego materiału do tematu")]
        public List<MaterialBase> SubjectMaterials { get; set; }

        public SubjectBase(Int16 number, String subjectName)
        {
            this.Number = number;
            this.Name = subjectName;
        }

        public SubjectBase(Int16 ID, Int16 number, String subjectName)
        {
            this.Number = number;
            this.ID = ID;
            this.Name = subjectName;
        }

        
    }
}