using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvcTutorial.Models
{
    public static class ProjectFactory
    {
        private static Project project = null;

        public static Project getProject()
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
            Course c1 = new Course(1, "Framework ASP.NET MVC dla początkujących");
            c1.ID = 1; // TODO: konstruktor z ID
            c1.Description = "Kurs przeznaczony jest dla programistów .NET, pragnących poznać wzorzec MVC oraz oparte na nim najnowsze środowisko Microsoft ASP.NET MVC służące do rozwijania aplikacji internetowych. ";
            c1.Description += "Program kursu obejmuje również podstawowe wiadomości na temat Entity Framework";
            c1.EstimatedDuration = 3;

            Module m1 = new Module(1, "Podstawy ASP.NET MVC");
            m1.ID = 1; // TODO: konstruktor z ID
            Subject s1 = new Subject(1, 1, "Historia platform webowych firmy Microsoft");
            Material mt = new Material(1, "", "", @"
            <b>Active Server Pages (ASP)</b><br />
            To pierwsza platforma do tworzenia aplikacji internetowych opracowana przez Microsoft, wydana w 1996 roku jako dodatek do serwera IIS. Strona aplikacji składała się ze znaczników HTML
            oraz kodu umieszczonego w tym samym pliku witryny internetowej z charakterystycznym rozszerzeniem .asp. Do pisania kodu można było użyć jednego z obsługiwanych przez platformę
            języków skryptowych (m.in. VBScript oraz JScript). <br /><br />
            <b>ASP.NET Web Forms</b><br />
            Ta platforma, opracowana przez Microsoft w roku 2002 jako następca ASP w technologii .NET, pozwalała już na oddzielenie pliku kodu od pliku znaczników. Była próbą przeniesienia mechanizmów
            programowania zdarzeniowego znanego z Windows Forms na płaszczyznę technologii internetowych. Strona aplikacji składała się z pliku znaczników definiującego w formacie HTML i XML 
            kontrolki przekształcane przez framework do postaci strony interfejsu WWW wyświetlanego w przeglądarce oraz z kodu napisanego w .NET obsługującego po stronie serwera zdarzenia
            wygenerowane przez użytkownika w tym interfejsie. W celu pisania kodu po stronie serwera można było wykorzystać języki programowania obsługiwane przez platformę .NET, takie jak
            Visual Basic czy C#.<br /><br />
            <b>ASP.NET MVC</b><br />
            To najnowsza platforma webowa firmy Microsoft, wydana w 2008 roku. W przeciwieństwie do ASP.NET Web Forms nie zastępuje ona swojej poprzedniczki, ale oferuje równoległy, alternatywny
            model tworzenia aplikacji internetowych, oparty na architekturze MVC (Model-View-Controller).             
            ");
            s1.SubjectMaterials = new List<MaterialBase>() { mt };
            Test test = new Test(s1.Name, 1, TestType.Static);
            Quiz q1 = new Quiz(1, "Lata wydania platform", "W jakich latach nastąpiło wydanie przez firmę Microsoft kolejnych kluczowych platform tworzenia aplikacji internetowych?", 

                                    new List<Answer>() { new Answer("A", "1992, 2000, 2005", false), 
                                                         new Answer("B", "1996, 2002, 2008", true), 
                                                         new Answer("C","1996, 2000, 2008", false), 
                                                         new Answer("D", "1998, 2002, 2008", false) });
            Quiz q2 = new Quiz(2, "Pytanie o funkcję kontrolera", "Która warstwa architektury MVC odpowiada za reagowanie na akcje użytkownika?",
                new List<Answer>() { new Answer("1", "Model", false), 
                                                new Answer("2", "Kontroler", true), 
                                                new Answer("3", "Widok", false) });
            test.QuizeList = new List<Quiz>() { q1, q2 };

            s1.SubjectTest = test;
            Subject s2 = new Subject(2, 2, "Architektura MVC");
            mt = new Material(1, "", "", @"
            Architektura MVC opiera się na podziale aplikacji na trzy niezależne, współpracujące ze sobą warstwy: Modelu, Kontrolera i Widoku.
            <br /><br />
            <b>Model</b><br />
            Warstwa modelu reprezentuje dane modelowanej dziedziny. Są to klasy hermetyzujące właściwości i metody operujące na encjach biznesowych.
            <br /><br />
            <b>Widok</b><br />
            Widok jest warstwą, która odpowiada za wizualną reprezentację obiektów z warstwy modelu. Przekształca ona dane do postaci, w której mają one
            być udostępnione użytkownikowi aplikacji, np. do formatu HTML, PDF, XML czy XLS.
            <br /><br />
            <b>Kontroler</b><br />
            Kontroler odpowiedzialny jest za logikę aplikacji, stanowi łącznik pomiędzy widokiem i modelem. Reaguje na akcje wywoływane przez użytkownika
            z poziomu interfejsu, wykonuje żądane przez nie operacje na modelu, a następnie zwraca rezultat tych operacji do widoku.            
            ");
            s2.SubjectMaterials = new List<MaterialBase>() { mt };
            test = new Test(s2.Name, 1, TestType.Static);
            q1 = new Quiz(1, "Pytanie o funkcję kontrolera", "Która warstwa architektury MVC odpowiada za reagowanie na akcje użytkownika?", 
                            new List<Answer>() { new Answer("1", "Model", false), 
                                                new Answer("2", "Kontroler", true), 
                                                new Answer("3", "Widok", false) });
            test.QuizeList = new List<Quiz>() { q1 };
            
            s2.SubjectTest = test;

            Subject s3 = new Subject(3, 3, "Instalacja narzędzi");
            mt = new Material(1, "", "", @"
            Składniki oprogramowania wymagane do tworzenia aplikacji w technologii ASP.NET MVC to: <br /><br />
            - środowisko Visual Studio lub Visual Web Developer (wersja 2010, 2012 lub 2013)<br />
            - aplikacja PowerShell 2.0<br />
            - platforma ASP.NET MVC<br /><br />
            Wszystkie potrzebne programy można pobrać ze stron firmy Microsoft: <a href=""http://asp.net/downloads"" style=""text-decoration: underline"">http://asp.net/downloads</a>
            ");
            s3.SubjectMaterials = new List<MaterialBase>() { mt };
            Subject s4 = new Subject(4, 4, "Tworzenie aplikacji");
            s4.SubjectMaterials = new List<MaterialBase>();
            mt = new Material(1, "", "", @"
            <b>Szablony projektów</b><br/><br/>
            Podczas tworzenia nowej aplikacji ASP.NET MVC mamy do wyboru kilka szablonów projektów:<br/><br/>
            - <b>Pusta</b>: tworzy aplikację ze strukturą katalogów, referencjami do bibliotek ASP.NET MVC oraz bibliotekami JavaScript, domyślnym układem widoku
              i plikiem Global.asax ze standardową konfiguracją aplikacji<br/>
            - <b>Podstawowe</b>: zawiera tylko strutkturę katalogów i referecnje do bibliotek ASP.NET MVC - jest to szablon miminalny<br/>
            - <b>Aplikacja internetowa</b> - stanowi rozszerzenie szablonu Pusta, zawiera kontroler domyślny <i>HomeController</i> oraz kontroler <i>AccountController</i>
              obsługujący rejestrację i logowanie użytkowników, a ponadto widoki dla obu kontrolerów<br/>
            - <b>Aplikacja intranetowa</b> - podobny do szablony Aplikacji Internetowej, ale z konfiguracją zawierającą uwierzytelnianie oparte na Windows<br/>
            - <b>Aplikacja dla urządzeń przenośnych</b> - wersja szablonu Aplikacji Internetowej zoptymalizowana pod aplikacje dla urządzeń mobilnych i wykorzystująca
              bibliotekę jQuery Mobile<br/>
            - <b>Interfejs WebApi</b> - zawiera wstępnie skonfigurowany kontroler dla WebApi, czyli nowej lekkiej platformy usług sieciowych RESTful HTTP<br/>
            <a href=""/Content/multimedia/TworzenieAplikacjiAspNetMvc/index.html"" target=""_new"" style=""text-decoration:underline"">
                <table border=""0""><tr>
                <td width=""32"" style=""padding: 3px""><img src=""/Content/images/video_camera.png""/></td>
                <td valign=""middle"">Obejrzyj prezentację procesu tworzenia nowej aplikacji ASP.NET MVC</td>
                </tr></table>
            </a>
            ");
            s4.SubjectMaterials.Add(mt);
            mt = new Material(2, "", "", @"
            <b>NuGet - narzędzie do zarządzania pakietami</b><br /><br />
            Menedżer pakietów NuGet jest jedną z nowości w projektach ASP.NET MVC 4. Jego głównym zadaniem jest zarządzanie zależnościami pomiędzy bibliotekami
            używanymi w projekcie. Dana biblioteka może zależeć od innej biblioteki, w dodatku od jej konkretnej wersji. NuGet sprawdza te wszystkie skomplikowane
            zależności i gwarantuje, że właściwa wersja odpowiedniego podzespołu jest dostępna dla naszej aplikacji. Menedżera NuGet ma dwa podstawowe tryby obsługi:<br/><br/>
            <b>Graficzny</b> - dostępny w Eksploratorze rozwiązania po kliknięciu projektu prawym przyciskiem myszy i wybraniu opcji ""Zarządzaj pakietami NuGet""<br/><br/>
            <b>Konsola</b> - można ją wyświetlić po wybraniu menu Narzędza / Menedżer pakietów bibliotek / Konsola Menedżera pakietów. W konsoli możemy instalować
            pakiety używając polecenia <i>Insall-Package</i>, np. aby zainstalować Entity Framework należy użyć polecenia <i>Install-Package EntityFramework</i>.
            ");
            s4.SubjectMaterials.Add(mt);
            mt = new Material(3, "", "", @"
            <b>Konwencja przed konfiguracją</b>

            ");
            s4.SubjectMaterials.Add(mt);
            mt = new Material(4, "", "", @"
            <b>Routing</b>
            ");
            s4.SubjectMaterials.Add(mt);
            mt = new Material(5, "", "", @"
            <b>Kontrolery</b>
            ");
            s4.SubjectMaterials.Add(mt);
            mt = new Material(6, "", "", @"
            <b>Obiekt ActionResult</b>
            ");
            s4.SubjectMaterials.Add(mt);
            mt = new Material(7, "", "", @"
            <b>Parametry i dołączanie modelu</b>
            ");
            s4.SubjectMaterials.Add(mt);            
            Subject s5 = new Subject(5, 5, "Widoki");
            mt = new Material(1, "", "", @"
            ");
            s5.SubjectMaterials = new List<MaterialBase>();
            mt = new Material(1, "", "", @"
            <b>Podstawy składni Razor</b>
            ");
            s5.SubjectMaterials.Add(mt);
            mt = new Material(2, "", "", @"
            <b>Układy graficzne</b>
            ");
            s5.SubjectMaterials.Add(mt);
            mt = new Material(3, "", "", @"
            <b>Widoki częściowe</b>
            ");
            s5.SubjectMaterials.Add(mt);
            mt = new Material(4, "", "", @"
            <b>Wyświetlanie danych</b>
            ");
            s5.SubjectMaterials.Add(mt);
            Subject s6 = new Subject(6, 6, "Modele");
            mt = new Material(1, "", "", @"
            ");
            s6.SubjectMaterials = new List<MaterialBase>() { mt };
            Subject s7 = new Subject(7, 7, "Uwierzytelnianie");
            mt = new Material(1, "", "", @"
            ");
            s7.SubjectMaterials = new List<MaterialBase>() { mt };

            m1.ModuleSubjects = new List<SubjectBase>() { s1, s2, s3, s4, s5, s6, s7 };

            Module m2 = new Module(2, "Praca z danymi");
            m2.ID = 2;
            s1 = new Subject(8, 1, "Tworzenie formularza");
            mt = new Material(1, "", "", @"
            ");
            s1.SubjectMaterials = new List<MaterialBase>() { mt };
            s2 = new Subject(9, 2, "Obsługa akcji POST");
            mt = new Material(1, "", "", @"
            ");
            s2.SubjectMaterials = new List<MaterialBase>() { mt };
            s3 = new Subject(10, 3, "Technika Code First");
            mt = new Material(1, "", "", @"
            ");
            s3.SubjectMaterials = new List<MaterialBase>() { mt };
            s4 = new Subject(11, 4, "Entity Framework");
            mt = new Material(1, "", "", @"
            ");
            s4.SubjectMaterials = new List<MaterialBase>() { mt };
            s5 = new Subject(12, 5, "Walidacja przy pomocy adnotacji");
            mt = new Material(1, "", "", @"
            ");
            s5.SubjectMaterials = new List<MaterialBase>() { mt };
            s6 = new Subject(13, 6, "Wyświetlanie komunikatów o błędach");
            mt = new Material(1, "", "", @"
            ");
            s6.SubjectMaterials = new List<MaterialBase>() { mt };

            m2.ModuleSubjects = new List<SubjectBase>() { s1, s2, s3, s4, s5, s6 };

            c1.CourseModules = new List<Module>() { m1, m2 };

            Course c2 = new Course(2, "Zaawansowane programowanie w języku JavaScript");
            c2.ID = 2;
            c2.EstimatedDuration = 8;

            p.ProjectCourses = new List<Course>() { c1, c2 };

            
        } 
    }
}