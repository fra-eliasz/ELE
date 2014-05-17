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
        public Material(String materialName, String materialDesc, String materialBody) :
            base(materialName, materialDesc, materialBody)
        {            
        }

    }
}
