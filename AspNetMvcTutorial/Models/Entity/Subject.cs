using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvcTutorial.Models
{
    public class Subject : SubjectBase
    {
        public Subject(String name)
            : base(name)
        {
        }

        public Subject(Int16 ID, String name)
            : base(ID, name)
        {
        }

        
        Test SubjectTest { set; get; } 
    }
}