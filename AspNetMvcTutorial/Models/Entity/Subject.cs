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
        
        Test SubjectTest { set; get; } 
    }
}