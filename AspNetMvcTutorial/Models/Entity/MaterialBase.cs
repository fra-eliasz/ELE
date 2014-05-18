using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AspNetMvcTutorial.Models
{
    public class MaterialBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        Int16 ID { get; set; }

        [Required(ErrorMessage = "Wymagane jest podanie numeru materia³u")]
        public Int16 Number { get; set; }

        [Required(ErrorMessage = "Wymagane jest podanie nazwy materia³u")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Wymagane jest podanie opisu materia³u")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Wymagane jest podanie treœci materia³u")]
        public String MaterialContent { get; set; }

        public MaterialType Type { get; set; }

        public MaterialBase(Int16 number, String materialName, String materialDesc, String materialContent)
        {
            this.Number = number;
            this.Name = materialName;
            this.Description = materialDesc;
            this.MaterialContent = materialContent;
            this.Type = MaterialType.Static;
        }

        public MaterialBase(Int16 number, String materialName, String materialDesc, String materialContent, MaterialType materialType)
        {
            this.Number = number;
            this.Name = materialName;
            this.Description = materialDesc;
            this.MaterialContent = materialContent;
            this.Type = materialType;
        }


    }
}
