using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetMvcTutorial.Models;
using AspNetMvcTutorial.Models.Entity;

namespace AspNetMvcTutorial.Controllers
{
    public class CourseController : Controller
    {
        Project project = ProjectFactory.getProject();
        Int16 materialNumber;
        Int16 courseId;
        Int16 moduleId;

        Course course;
        Module module;
        Subject subject;
        Int16 currentQuizId;
        UserTestHistory userTests;

        public CourseController()
        {
            materialNumber = -1;
            courseId = -1;
            moduleId = -1;

            userTests = new UserTestHistory();

        }

        public ActionResult Main(Int16 id)
        {
            Session["courseId"] = id;
            Project project = ProjectFactory.getProject();
            Course course = project.ProjectCourses.FirstOrDefault(c => c.ID == id);

            ViewBag.Title = "Kurs \"" + course.Name + "\"";

            return View("Main", course);
        }

        public ActionResult Module(Int16 id)
        {
            Session["moduleId"] = id;
            courseId = (Int16)Session["courseId"];

            course = project.ProjectCourses.FirstOrDefault(c => c.ID == courseId);
            ViewBag.CourseName = course.Name;
            ViewBag.CourseId = course.ID;

            module = course.CourseModules.FirstOrDefault(m => m.ID == id);

            ViewBag.Title = "Kurs \"" + course.Name + "\"";

            if (Session["UserTestHistory"] == null)
                Session["UserTestHistory"] = userTests;

            return View("Module", module);
        }

        public ActionResult Subject(Int16 id, Int16 number)
        {
            materialNumber = number;
            setCourseModulSubject(id);

            setViewBag();

            return View("Subject", subject);
        }

        private void setViewBag()
        {
            ViewBag.CourseName = course.Name;
            ViewBag.CourseId = course.ID;
            ViewBag.ModuleName = module.Name;
            ViewBag.ModuleId = module.ID;
            ViewBag.PrevSubjectId = subject.Number == 1 ? 0 : module.ModuleSubjects.FirstOrDefault<SubjectBase>(s => s.Number == subject.Number - 1).ID;
            ViewBag.NextSubjectId = subject.Number == module.ModuleSubjects.Count() ? 0 : module.ModuleSubjects.FirstOrDefault<SubjectBase>(s => s.Number == subject.Number + 1).ID;
            ViewBag.MaterialNumber = materialNumber;
            ViewBag.MaterialCount = subject.SubjectMaterials.Count();
            ViewBag.Material = subject.SubjectMaterials.FirstOrDefault(m => m.Number == materialNumber);
            ViewBag.DoTest = (ViewBag.MaterialNumber == ViewBag.MaterialCount + 1);
            
            ViewBag.Title = "Kurs \"" + course.Name + "\"";
            
        }

        private void setCourseModulSubject(Int16 id)
        {
            courseId = (Int16)Session["courseId"];

            course = project.ProjectCourses.FirstOrDefault(c => c.ID == courseId);
            moduleId = (Int16)Session["moduleId"];

            module = course.CourseModules.FirstOrDefault(m => m.ID == moduleId);
            subject = (Subject)module.ModuleSubjects.FirstOrDefault(s => s.ID == id);
            Session["subjectId"] = id;
            if(materialNumber != -1)
                Session["materialNumber"] = materialNumber;
            else
                materialNumber = ((Int16)Session["materialNumber"]);
        }

        [HttpGet]
        public ActionResult RenderQuiz(Test subjectTest)
        {
            materialNumber = Convert.ToInt16(Session["materialNumber"]);
            setCourseModulSubject(Convert.ToInt16(Session["subjectId"]));

            if (Session["ReturnMessage"] != null)
            {
                ViewBag.ReturnMessage = Session["ReturnMessage"];
                Session["ReturnMessage"] = null;
            }

            if (Session["UserAnswers"] != null)
            {
                ViewBag.UserAnswers = Session["UserAnswers"];
                Session["UserAnswers"] = null;
            }
            if (Session["WrongAnswers"] != null)
            {
                ViewBag.WrongAnswers = Session["WrongAnswers"];
                Session["WrongAnswers"] = null;
            }

            if(subjectTest.TestType.Equals(TestType.Static))
                return PartialView("Quizes/StaticQuiz", subjectTest);

            else
                return PartialView("Quizes/DragAndDropQuiz", subjectTest);
        }

        [HttpPost]
        public ActionResult AnswerQuiz(string [] userSelections)
        {
            setCourseModulSubject((Int16)Session["subjectId"]);
            List<Quiz> quizzes = subject.SubjectTest.TestQuizzes;

            Dictionary<int, List<string>> userAnswers = new Dictionary<int, List<string>>();

            if (userSelections != null)
            {
                foreach (string userSelection in userSelections)
                {
                    string[] items = userSelection.Split('_');
                    int quizNo = Convert.ToInt32(items[0]);
                    string answerCode = items[1];
                    if (!userAnswers.ContainsKey(quizNo))
                        userAnswers[quizNo] = new List<string>();
                    userAnswers[quizNo].Add(answerCode);
                }
            }

            Dictionary<int, List<string>> wrongAnswers = new Dictionary<int, List<string>>();

            foreach (Quiz quiz in quizzes)
            {
                foreach (Answer answer in quiz.Answers)
                {
                    bool userCheckedThisAnswer = userAnswers.ContainsKey(quiz.Number) && userAnswers[quiz.Number].Contains(answer.Name);
                    if (userCheckedThisAnswer != answer.Correct)
                    {
                        if (!wrongAnswers.ContainsKey(quiz.Number))                        
                            wrongAnswers[quiz.Number] = new List<string>();
                        wrongAnswers[quiz.Number].Add(answer.Name);                        
                    }
                }
            }

            if (wrongAnswers.Keys.Count() == 0)
            {
                // 100% poprawny wynik testu
                Session["ReturnMessage"] = "<span class=\"testResultOk\">Wynik: 100% poprawnych odpowiedzi. Gratulujemy!</span>";
            }
            else
            {
                // były błędy w odpowiedziach, informujemy o nich                
                int total = quizzes.Count();
                int wrong =  wrongAnswers.Keys.Count();
                int good = total - wrong;
                decimal percentResult = (decimal)good / (decimal)total * 100;
                Session["ReturnMessage"] = "<span class=\"testResultErrors\">Wynik: " + ((int)percentResult).ToString() + "%.  Nieprawidłowe odpowiedzi w pytani" + (wrong == 1 ? "u: " : "ach: ") + String.Join(", ", wrongAnswers.Keys.ToArray()) + " . Spróbuj ponownie!</span>";
            }

            Session["UserAnswers"] = userAnswers;
            Session["WrongAnswers"] = wrongAnswers;

            return Redirect(String.Format("/Course/Subject/{0}/{1}",subject.ID, subject.SubjectMaterials.Count() + 1));                


            /*
            int i=0;
            int corCnt = 0;
            int qAcc = 0;
            foreach(Quiz quest in quizeList){ corCnt += quest.Answers.FindAll(a => a.Correct == true).Count; }

            int qID = 0;

            
            if (userAnswer.Length >0 ) // <= corCnt)
            {
                while (qID <= quizeList.Count-1)
                {
                    qAcc += quizeList[qID].Answers.FindAll(a => a.Correct.Equals(true)).Count;
                
                    foreach (Answer correctAns in quizeList[qID].Answers.FindAll(a => a.Correct.Equals(true)))
                    {
                        for (int id = 0; id < userAnswer.Length; id++)
                        {
                            if (Convert.ToInt32(userAnswer[id].Split('_')[0]).Equals(quizeList[qID].Number) &&
                                userAnswer[id].Split('_')[1].Equals(correctAns.Name))
                            {
                                i++;
                                if (i == qAcc)
                                    break;
                            }
                        }
                    }
                    qID++;
                }
            }
            

            Console.Out.WriteLine("Score result "+ i + "/" +  corCnt);

            if (i == corCnt)
            {
                userTests = Session["UserTestHistory"] as UserTestHistory;
                if (userTests.subjectTestHistory.Count > 0)
                {
                    foreach (TestScore score in userTests.subjectTestHistory)
                    {
                        if (score.courseID == courseId && score.moduleID == moduleId && score.subjectID == materialNumber)
                            score.userScore += 1;
                    }
                }
                else
                {
                    TestScore tScore = new TestScore();
                    tScore.courseID = courseId;
                    tScore.moduleID = moduleId;
                    tScore.subjectID = materialNumber;
                    tScore.userScore += 1;
                    userTests.subjectTestHistory.Add(tScore);
                }
                Session["UserTestHistory"] = userTests;
                if(course.CourseModules.Count ==  module.ModuleSubjects.Count)
                    Console.Out.WriteLine("Score result " + i + "/" + corCnt);

                if (module.ModuleSubjects.Count > 1 && module.ModuleSubjects.Count > moduleId + 1)
                    return Redirect(String.Format("/Course/Subject/{0}/{1}",
                                new String[] { (moduleId+1).ToString(), "1"}));
                else
                    return Redirect(String.Format("/Course/Main/{0}", new String[] { courseId.ToString() }));
            }
            else
            {
                Session["ReturnMessage"] = "Nieprawidłowa odpowiedź, bądź podałeś nie pełny wynik.<br />Spróbuj ponownie!";
                return Redirect(String.Format("/Course/Subject/{0}/{1}",
                                new String[] { courseId.ToString(), (moduleId+1).ToString()}));
            }
            */

            return View();
        }

    }
}
