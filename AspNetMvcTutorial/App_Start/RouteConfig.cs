using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetMvcTutorial
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Extended",
                url: "{controller}/{action}/{id}/{number}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, number = UrlParameter.Optional }
            );

	    routes.MapRoute(
                name: "SubjectQuiz",
                url: "{controller}/{action}/{subjectID}/{number}/{quizId}",
                defaults: new { controller = "Subject", action = "RenderQuizPage", subjectID = UrlParameter.Optional, number = UrlParameter.Optional, quizId = UrlParameter.Optional }
            );
	}
    }
}