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
        //
        // GET: /Home/

        public ActionResult Main(Int16 id)
        {
            Session["courseId"] = id;
            Project project = ProjectFactory.CreateProject();
            Course course = project.ProjectCourses.FirstOrDefault(c => c.ID == id);

            ViewBag.Title = "Kurs \"" + course.Name + "\"";
            
            return View("Main", course);
        }

        public ActionResult Module(Int16 id)
        {
            Session["moduleId"] = id;
            Project project = ProjectFactory.CreateProject();
            Int16 courseId = (Int16)Session["courseId"];
            Course course = project.ProjectCourses.FirstOrDefault(c => c.ID == courseId);
            ViewBag.CourseName = course.Name;
            Module module = course.CourseModules.FirstOrDefault(m => m.ID == id);

            ViewBag.Title = "Kurs \"" + course.Name + "\"";

            return View("Module", module);
        }


    }
}
