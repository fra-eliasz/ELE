using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AspNetMvcTutorial.Models
{
    public class Material: MaterialBase
    {
        public Material(Int16 materialNumber, String materialName, String materialDesc, String materialBody) :
            base(materialNumber, materialName, materialDesc, materialBody)
        {            
        }

    }
}
