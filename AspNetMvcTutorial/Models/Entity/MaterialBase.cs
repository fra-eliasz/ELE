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

        [Required(ErrorMessage = "Material Name is required")]
        String Name { get; set; }

        [Required(ErrorMessage = "Material Description is required")]
        String Description { get; set; }

        [Required(ErrorMessage = "Material Body is required")]
        String MaterialBody { get; set; }

        MaterialType Type { get; set; }

        public MaterialBase(String materialName, String materialDesc, String materialBody)
        {
            this.Name = materialName;
            this.Description = materialDesc;
            this.MaterialBody = materialBody;
        }

        public MaterialBase(String materialName, String materialDesc, String materialBody, MaterialType materialType)
        {
            this.Name = materialName;
            this.Description = materialDesc;
            this.MaterialBody = materialBody;
            this.Type = materialType;
        }


    }
}
