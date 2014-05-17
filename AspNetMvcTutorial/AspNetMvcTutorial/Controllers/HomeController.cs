using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcTutorial.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Title = "Witamy!";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "Informacje o projekcie";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Zespół projektowy";
            return View();
        }

    }
}
