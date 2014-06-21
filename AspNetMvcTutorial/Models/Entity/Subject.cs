using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvcTutorial.Models
{
    public class Subject : SubjectBase
    {
        public Subject(Int16 number, String name)
            : base(number, name)
        {
        }

        public Subject(Int16 ID, Int16 number, String name)
            : base(ID, number, name)
        {
        }

        
        public Test SubjectTest { set; get; } 
    }
}