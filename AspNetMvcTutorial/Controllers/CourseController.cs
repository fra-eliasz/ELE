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
        
        private void setViewBag_Quiz()
        {
            ViewBag.prevQuiz = (subject.SubjectTest.QuizeList.Count > 1 ) && (((Int16)currentQuizId - 1) >= 0) ? 
                                            ((Int16)currentQuizId - 1).ToString() : "";
            ViewBag.nextQuiz = (subject.SubjectTest.QuizeList.Count > 1) && (((Int16)currentQuizId + 1) < subject.SubjectTest.QuizeList.Count) ? 
                                            ((Int16)currentQuizId + 1).ToString() : ""; 
            ViewBag.QuizName = subject.SubjectTest.QuizeList[currentQuizId].Name;
            ViewBag.QuestionText = subject.SubjectTest.QuizeList[currentQuizId].QuestionText;
            ViewBag.MaterialNumber = materialNumber;
            ViewBag.currentQuizID = currentQuizId;
        }
               
        public ActionResult RenderQuizPage(Int16 subjectID, Int16 number, Int16 quizId)
        {
            materialNumber = number;
            setCourseModulSubject(subjectID);
            currentQuizId = quizId;
            setViewBag();
            setViewBag_Quiz();

            Session["quizId"] = currentQuizId;

            return View("Subject", subject);
        }

        [HttpGet]
        public ActionResult RenderQuiz(Test subjectTest)
        {
            materialNumber = Convert.ToInt16(Session["materialNumber"]);
            setCourseModulSubject(Convert.ToInt16(Session["subjectId"]));

            if (Session["quizId"] != null)
            {
                ViewBag.Question = subjectTest.QuizeList[Convert.ToInt16(Session["quizId"])].QuestionText;
                currentQuizId = Convert.ToInt16(Session["quizId"]);
            }
            else
            {
                currentQuizId = 0;
                ViewBag.Question = subjectTest.QuizeList[currentQuizId].QuestionText;
            }

            Session["quizId"] = currentQuizId;
            setViewBag_Quiz();

            if(subjectTest.TestType.Equals(TestType.Static))
                return PartialView("Quizes/StaticQuiz", subjectTest);

            else
                return PartialView("Quizes/DragAndDropQuiz", subjectTest);
        }

        [HttpPost]
        public ActionResult AnswerQuiz(string [] userAnswer)
        {
            setCourseModulSubject((Int16)Session["subjectId"]);
            
            Quiz currentQuize = subject.SubjectTest.QuizeList[Convert.ToInt16(Session["quizId"])];
            int i=0;
            int corCnt = currentQuize.Answers.FindAll(a => a.Correct.Equals(true)).Count;

            if (userAnswer.Length == corCnt)
            {
                for (int id = 0; id < userAnswer.Length; id++)
                {
                    foreach(Answer correctAns in currentQuize.Answers.FindAll(a => a.Correct.Equals(true)))
                    {
                        if (userAnswer[id].Equals(correctAns.Name))
                            i++;
                    }
                }
            }

            Console.Out.WriteLine("Score result "+ i + "/" +  currentQuize.Answers.Count);

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

                if ((subject.SubjectTest.QuizeList.Count > 1) && (((Int16)currentQuizId + 1) < subject.SubjectTest.QuizeList.Count))
                    return Redirect(String.Format("/Course/RenderQuizPage/{0}/{1}/{2}",
                                new String[] { courseId.ToString(), moduleId.ToString(), ((Int16)currentQuizId + 1).ToString() }));
                else
                    return Redirect(String.Format("/Course/Main/{0}", new String[] { moduleId.ToString() }));
            }
            else
            {
                ViewBag.ReturnMessage = "Nie poprawna odpowiedź, bądź podałeś nie pełny wynik.<br />Spróbuj ponownie!";
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

    }
}
