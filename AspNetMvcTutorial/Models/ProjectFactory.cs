using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvcTutorial.Models
{
    public static class ProjectFactory
    {
        private static Project project = null;

        public static Project CreateProject()
        {
            if (project == null)
            {
                project = new Project("Platforma edukacyjna ELE");
                initProject(project);
            }
            return project;
        }

        private static void initProject(Project p)
        {
            Course c1 = new Course("Framework ASP.NET MVC dla początkujących");
            c1.ID = 1;
            c1.Description = "Kurs przeznaczony jest dla programistów .NET, pragnących poznać wzorzec MVC oraz oparte na nim najnowsze środowisko Microsoft ASP.NET MVC służące do rozwijania aplikacji internetowych. ";
            c1.Description += "Program kursu obejmuje również podstawowe wiadomości na temat Entity Framework";
            c1.EstimatedDuration = 3;

            Module m1 = new Module("Podstawy ASP.NET MVC");
            m1.ID = 1;
            Subject s1 = new Subject(1, "Historia platform webowych firmy Microsoft");
            Subject s2 = new Subject(2, "Architektura MVC");
            Subject s3 = new Subject(3, "Instalacja narzędzi");
            Subject s4 = new Subject(4, "Tworzenie aplikacji");
            Subject s5 = new Subject(5, "Widoki");
            Subject s6 = new Subject(6, "Modele");
            Subject s7 = new Subject(7, "Uwierzytelnianie");
            m1.ModuleSubjects = new List<SubjectBase>() { s1, s2, s3, s4, s5, s6, s7 };

            Module m2 = new Module("Praca z danymi");
            m2.ID = 2;
            s1 = new Subject(8, "Tworzenie formularza");
            s2 = new Subject(9, "Obsługa akcji POST");
            s3 = new Subject(10,"Technika Code First");
            s4 = new Subject(11,"Entity Framework");
            s5 = new Subject(12,"Walidacja przy pomocy adnotacji");
            s6 = new Subject(13,"Wyświetlanie komunikatów o błędach");

            m2.ModuleSubjects = new List<SubjectBase>() { s1, s2, s3, s4, s5, s6 };

            c1.CourseModules = new List<Module>() { m1, m2 };

            Course c2 = new Course("Zaawansowane programowanie w języku JavaScript");
            c2.ID = 2;
            c2.EstimatedDuration = 8;

            p.ProjectCourses = new List<Course>() { c1, c2 };

            
        }
    }
}