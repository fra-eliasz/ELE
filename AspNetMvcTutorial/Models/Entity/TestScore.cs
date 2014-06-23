using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetMvcTutorial.Models.Entity
{
    public class TestScore
    {
        public Int32 subjectID { set; get; }
        public Int32 moduleID { set; get; }
        public Int32 courseID { set; get; }

        public Int16 userScore { set; get; }
        public Int16 TotalScore { set; get; }
        public Double Percentage { set { Percentage = value;} get{ try{return (userScore/TotalScore)*100; }
                                                 catch (DivideByZeroException){ return 0;} }}

    }
}
