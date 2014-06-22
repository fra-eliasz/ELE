using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvcTutorial.Models.Entity
{
    public class UserTestHistory
    {
        public List<TestScore> subjectTestHistory;
        public string userName { set; get; }
        public Int32 userID { set; get; }

        public UserTestHistory()
        {
            this.subjectTestHistory = new List<TestScore>();
            this.userID = -1;
            this.userName = "Gal Anonim";
        }

        public void addTest(TestScore test){
            subjectTestHistory.Add(test);
        }
    }
}