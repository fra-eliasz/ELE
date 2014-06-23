using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetMvcTutorial.Models;

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

        public CourseController()
        {
            materialNumber = -1;
            courseId = -1;
            moduleId = -1;
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

            return View("Module", module);
        }

        public ActionResult Subject(Int16 id, Int16 number)
        {
            materialNumber = number;
            courseId = (Int16)Session["courseId"];

            course = project.ProjectCourses.FirstOrDefault(c => c.ID == courseId);
            ViewBag.CourseName = course.Name;
            ViewBag.CourseId = course.ID;

            moduleId = (Int16)Session["moduleId"];

            module = course.CourseModules.FirstOrDefault(m => m.ID == moduleId);
            ViewBag.ModuleName = module.Name;
            ViewBag.ModuleId = module.ID;

            subject = (Subject)module.ModuleSubjects.FirstOrDefault(s => s.ID == id);
            ViewBag.PrevSubjectId = subject.Number == 1 ? 0 : module.ModuleSubjects.FirstOrDefault<SubjectBase>(s => s.Number == subject.Number - 1).ID;
            ViewBag.NextSubjectId = subject.Number == module.ModuleSubjects.Count() ? 0 : module.ModuleSubjects.FirstOrDefault<SubjectBase>(s => s.Number == subject.Number + 1).ID;
            ViewBag.MaterialNumber = materialNumber;
            ViewBag.MaterialCount = subject.SubjectMaterials.Count();
            ViewBag.Material = subject.SubjectMaterials.FirstOrDefault(m => m.Number == materialNumber);            
            ViewBag.DoTest = ViewBag.MaterialNumber == ViewBag.MaterialCount + 1;

            ViewBag.Title = "Kurs \"" + course.Name + "\"";
            
            return View("Subject", subject);
        }

        [HttpGet]
        public ActionResult RenderTest(Test subjectTest)
        {
            if(subjectTest.TestType.Equals(TestType.Static))
                return PartialView("Quizes/StaticQuiz",subjectTest);

            else
                return PartialView("Quizes/DragAndDropQuiz", subjectTest);
        }

        [HttpPost]
        public ActionResult AnswerQuiz()
        {

            return Redirect("/");
        }

    }
}
