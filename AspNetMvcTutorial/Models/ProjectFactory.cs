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

            test.TestQuizzes = new List<Quiz>() { q1 };
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
                            new List<Answer>() { new Answer("A", "Model", false), 
                                                new Answer("B", "Kontroler", true), 
                                                new Answer("C", "Widok", false) });

            test.TestQuizzes = new List<Quiz>() { q1 };
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
            - <b>Podstawowe</b>: zawiera tylko strukturę katalogów i referencje do bibliotek ASP.NET MVC - jest to szablon miminalny<br/>
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
            pakiety używając polecenia <i>Insall-Package</i>, np. aby zainstalować Entity Framework należy użyć polecenia <i>Install-Package EntityFramework</i>.<br/>            
            ");
            s4.SubjectMaterials.Add(mt);
            mt = new Material(3, "", "", @"
            <b>Konwencja przed konfiguracją</b><br/><br/>
            Platforma ASP.NET MVC wykorzystuje koncepcję <i>konwencji przed konfiguracją (ang. convention over configuration)</i>. Polega ona na tym, że wiele
            aspektów tworzenia aplikacji określanych jest nie przez explicite podane ustawienia konfiguracyjne, ale przez domyślne, implicite przyjęte konwencje.
            Dobrym przykładem na zastosowanie tej zasady jest struktura katalogów aplikacji. Katalogi <i>Controllers</i>, <i>Models</i> i <i>Views</i> są standardowymi
            lokalizacjami, w których framework spodziewa się znaleźć odpowiadające ich nazwom warstwy aplikacji: kontroler, modele i widoki. Kolejna konwencja
            występuje w nazwach klas: domyślnie dla kontrolera encji o nazwie <i>&lt;Nazwa&gt;</i> jej obsługą zajmował się będzie kontroler o nazwie <i>&lt;Nazwa&gt;Controller</i>.<br/>
            ");
            s4.SubjectMaterials.Add(mt);
            mt = new Material(4, "", "", @"
            <b>Routing</b><br/><br/>
            <i>Routing</i> jest mechanizmem analizy URL żądania skierowanego przez przeglądarkę do aplikacji w celu przekazania go do odpowiedniego kontrolera,
            który zajmie się jego obsługą. Analiza ta opiera się na dopasowywaniu URL żądania do wzorców zdefiniowanych w tzw. <i>tabeli routingu</i>. Domyślnym
            wzorcem URL stosowanym w aplikacjach MCV jest wzorzec:<br/><br/>
            {controller}/{action}/{id}<br/><br/> 
            Oznacza to, że po części URL określającej serwer i położenie
            aplikacji następuje trzyczłonowy, oddzielany ukośnikami adres, w któryn pierwszy człon definiuje, jaki kontroler ma obsłużyć żądanie, drugi,
            jaka metoda tego kontrolera ma je obsłużyć, zaś trzeci wyznacza identyfikator obiektu, którego dotyczy żądanie. Przykładowo, dla aplikacji 
            <i>ksiegowosc</i> umieszczonej na serwerze <i>mojserwer.pl</i> operacja aktualizacja konta o identyfikatorze 1239 mogłaby mieć formę żądania:<br/><br/>
            http://mojserwer.pl/ksiegowosc/konto/zapisz/1239
            <br/><br/>
            Dopasowanie tego zapytania przez mechanizm routingu do domyślnego schematu URL spowodowałoby obsługę tego żądania przez klasę KontoController, poprzez
            wywołanie jej metody zapisz(int id) z parametrem id = 1239.<br/>
            ");
            s4.SubjectMaterials.Add(mt);
            mt = new Material(5, "", "", @"
            <b>Kontrolery</b><br/><br/>
            Kontrolery stanowią warstwę wzorca MVC odpowiedzialną za reagowanie na akcje wykonywane przez użytkownika. Klasyczny zestaw tego typu akcji w
            aplikacjach biznesowych to tzw. <i>CRUD</i> (Create/Read/Update/Delete). Wykonanie akcji często związane jest z dostępem do danych, a więc do warstwy
            modelu wzorca MVC. Metody klasy kontrolera zwane są także <i>akcjami</i> i to one odpowiadają za przetworzenie żądania. Wykonywana akcja posługuje
            się zazwyczaj odpowiadającym jej <i>widokiem</i> do wyświetlenia odpowiedzi na żądanie użytkownika. 
            ");
            s4.SubjectMaterials.Add(mt);
            mt = new Material(6, "", "", @"
            <b>Obiekt ActionResult</b><br/><br/>
            Wszystkie akcje kontrolerów zwracają klasy pochodne względem bazowej klasy <i>ActionResult</i>. W ten sposób kontroler komunikuje, w jaki sposób
            ma zostać przetworzona/zaprezentowana treść odpowiedzi na zrealizowane żądanie użytkownika. W tym celu środowisko ASP.NET MVC wyposażone zostało
            w zestaw pomocniczych metod zwracających różne podtypy klasy ActionResult. Oto niektóre z nich:<br/><br/>
            <b>View()</b> - zwraca ViewResult, standardową odpowiedź kontrolera - powodującą wygenerowanie widoku zdefiniowanego w odpowiadającym kontrolerowi
            i akcji pliku widoku z katalogu Views aplikacji, z wykorzystaniem domyślnego układu<br/><br/>
            <b>PartialView()</b> - zwraca PartialViewResult - generuje widok częściowy, nie używający domyślnego układu<br/><br/>
            <b>Content()</b> - zwraca ContentResult - powoduje to wygenerowanie odpowiedzi zawierającej dowolny podany tekst<br/><br/>
            <b>File()</b> - zwraca FileResult, powoduje wyświetlenie zawartości podanego pliku<br/><br/>
            <b>JavaScript()</b> - zawraca JavaScriptResult - generuje skrypt JavaScript<br/><br/>
            <b>Json()</b> - zwraca JsonResult - generuje zawartość obiektu zserializowaną do formatu JSON<br/><br/>
            <b>Redirect()</b> - zwraca RedirectResult - żądanie przekierowania użytkownika na podany adres (z wykorzystaniem kodu 302 HTTP)<br/><br/>            
            ");
            s4.SubjectMaterials.Add(mt);
            mt = new Material(7, "", "", @"
            <b>Parametry i dołączanie modelu</b><br/><br/>
            Tradycyjny sposób pobierania przez aplikację parametrów żądania polegał na odwoływaniu się do predefiniowanego obiektu Request, np.: <br/><br/>
            var Book = new Book () { Title = Request[""title""], Price = Decimal.Parse(Request[""price""]) };
            <br/><br/>
            Prostszym sposobem jest wykorzystanie przekazywania wartości na podstawie nazw parametrów:<br/><br/>
            public ActionResult Create(string title, decimal price)<br/>
            {<br/>
            &nbsp;&nbsp;var book = new Book( Title = title, Price = price);<br/>                
            }<br/><br/>
            Najbardziej zaawansowany wariant to tzw. <i>dołączanie modelu</i>, polegające na określeniu typu złożonego, do którego właściwości mają
            zostać przypisane przekazywane w żądaniu wartości:<br/><br/>
            public ActionResult Create(Book book) {<br/>
            ...<br/>
            }<br/><br/>
            Ponadto parametry mogą być przekazywane także jako wynik parsowania URL żądania przez mechanizm routingu. Np. dla standardowego wzorca:<br/><br/>
            {controller}/{action}/{id}<br/><br/> 
            parametr id = 1239 z żądania <i>konto/edytuj/1239</i> zostanie przekazany na parametr id wywołania metody:<br/><br/>
            public ActionResult edytuj(long id) 
            ");
            s4.SubjectMaterials.Add(mt);
            test = new Test(s4.Name, 1, TestType.Static);
            test.TestQuizzes = new List<Quiz>();
            test.TestQuizzes.Add(new Quiz(1, "Pytanie o cechy szablonów", "Szablon Aplikacja Internetowa:",
                                                new List<Answer>() { new Answer("A", "zawiera tylko strukturę katalogów i referencje do bibliotek ASP.NET MVC", false), 
                                                new Answer("B", "zawiera kontrolery HomeController i AccountController oraz widoki dla nich", true), 
                                                new Answer("C", "ma skonfigurowane uwierzytelnianie oparte na Windows", false) }
                                          )
                                );
            test.TestQuizzes.Add(new Quiz(2, "Pytanie o routing", "Żądanie http://aplikacja.pl/pracodawca/pracownik/10 przy domyślnym schemacie routingu:",
                                                new List<Answer>() { new Answer("A", "Wywoła akcję Pracodawca kontrolera PracownikController", false), 
                                                new Answer("B", "Oznacza żądanie o zwrócenie 10 rekordów pracowników", false), 
                                                new Answer("C", "Wywoła akcję Pracownik kontrolera PracodawcaController", true) }
                                          )
                                );
            test.TestQuizzes.Add(new Quiz(3, "Pytanie o ActionResult", "Aby zwrócić odpowiedź zawierającą dowolnie określony tekst, kontroler powinien użyć metody:",
                                                new List<Answer>() { new Answer("A", "Content()", true), 
                                                new Answer("B", "PartialView()", false), 
                                                new Answer("C", "File()", false) }
                                          )
                                );
            s4.SubjectTest = test;
            Subject s5 = new Subject(5, 5, "Widoki");
            s5.SubjectMaterials = new List<MaterialBase>();
            mt = new Material(1, "", "", @"
            <b>Podstawy składni Razor</b><br/><br/>
            Składnia Razor różni się nieco od tej znanej z ASP.NET WebForms. Oto przykładowa lista pozycji wygenerowana przy pomocy ""starej"" składni 
            oraz przy pomocy składni Razor:<br/><br/>            
            <code>
            &lt;ul&gt;<br/>
            &lt;% foreach(val book in books) { %&gt;<br/>
            &nbsp;&nbsp;&lt;li&gt;&lt;: book.Title %&gt;&lt;/li&gt;<br/>
            &lt;% } %&gt;<br/>
            &lt;/ul&gt;<br/><br/>
            </code>
            <br/>
            <code>
            &lt;ul&gt;<br/>
            @foreach(val book in books) { <br/>
            &nbsp;&nbsp;&lt;li&gt;&lt;: @book.Title %&gt;&lt;/li&gt;<br/>
            }<br/>
            &lt;/ul&gt;<br/><br/>            
            </code>            
            Składnia Razor umożliwia umieszczanie kodu C# w treści strony na dwa sposoby. Pierwszy z nich to proste wyrażenia, czyli <i>pakiety kodu</i>, np.:<br/><br/>
            <code>
            Temat: @Model.Name (@Html.Raw(@prevMaterialLink) Test)
            </code><br/><br/>
            Drugi sposób to dłuższe <i>bloki kodu</i>, np.:<br/><br/>
            <code>
            @{<br/>
            &nbsp;&nbsp;var title = @Model.Title;<br/>
            &nbsp;&nbsp;var price = @Model.Price;<br/>
            }<br/>
            </code>
            ");
            s5.SubjectMaterials.Add(mt);
            mt = new Material(2, "", "", @"
            <b>Układy graficzne</b><br/><br/>
            Układ graficzny (ang. layout) to szablon wyglądu strony obowiązujący dla całej witryny bądź jej konkretnego obszaru. Dzięki jego zastosowaniu 
            możemy uzyskać spójny wygląd wszystkich stron wyświetlanych w ramach budowanej przez nas aplikacji. Zazwyczaj zawiera on style CSS oraz kod HTML
            definiujący ""ramy"" struktury stron oraz nazwane kontenery, w których widoki mogą wstawiać swoją własną treść. Oto przykładowy plik układu graficznego:<br/><br/>
            <code>
            &lt;html lang=""pl""&gt;<br/>
            &lt;head&gt;<br/>
        	&nbsp;&nbsp;&lt;meta charset=""utf-8""&gt;<br/>
            &nbsp;&nbsp;&lt;title&gt;@View.title&lt;/title&gt;<br/>
            &lt;/head&gt;<br/>
            &lt;body&gt;<br/>
            &nbsp;&nbsp;&lt;div class=""header""&gt;<br/>
            &nbsp;&nbsp;&nbsp;&nbsp;@RenderSection(""header"")<br/>
            &nbsp;&nbsp;&lt;/div&gt;<br/><br/>
                    
            &nbsp;&nbsp;@RenderBody() <br/><br/>

            &nbsp;&nbsp;&lt;div class=""footer""&gt;<br/>
            &nbsp;&nbsp;&nbsp;&nbsp;@RenderSection(""footer"")<br/>
            &nbsp;&nbsp;&lt;/div&gt;<br/>
            &lt;/body&gt;<br/>
            &lt;/html&gt;<br/>
            </code>
            <br/><br/>
            Odwołanie się przez widok do tak zdefiniowanego szablonu wygląda następująco:<br/><br/>
            <code>
            @{ Layout = ""-/_Layout.cshtml""; }<br/><br/>
            
            @section Header {<br/>
            &nbsp;&nbsp;Witamy na naszej stronie!<br/>
            }<br/><br/>
            @section Footer {<br/>
            &nbsp;&nbsp;(c) 2014 by Super Productions Ltd.<br/>
            }<br/><br/>

            &lt;div class=""content""&gt;<br/>
            &nbsp;&nbsp;Tutaj znajduje się podstawowa treść strony wyświetlana w sekcji RenderBody()<br/>
            &lt;/div&gt;<br/><br/>
            </code>
            ");
            s5.SubjectMaterials.Add(mt);
            mt = new Material(3, "", "", @"
            <b>Widoki częściowe</b><br/><br/>
            Widoki częściowe są to widoki pomyślane w taki sposób, aby mogły być prezentowane jako część składowa większego widoku. Dzięki ich zastosowaniu
            możliwe jest wyświetlanie określonych informacji w taki sam sposób na wielu stronach naszej witryny. Użycie widoków częściowych może znacząco
            uprościć kod widoku. Na przykład mając zdefiniowany widok częściowy wyświetlający opis pojedynczej książki, możemy listę wyszukanych książek wyświetlić
            w następujący sposób:<br/><br/>
            <code>
            @model IEnumerable<Book><br/><br/>
    
            Wyszukane książki:<br/><br/>

            foreach(var book in Model) {<br/>
            &nbsp;&nbsp;@Html.Partial(""Book"", book)<br/>
            }<br/>
            </code>
            ");
            s5.SubjectMaterials.Add(mt);
            mt = new Material(4, "", "", @"
            <b>Wyświetlanie danych</b><br/><br/>
            Wyświetlenie wyników akcji wymaga przekazania danych przez kontroler do widoku, co można uzyskać na kilka sposobów. Pojedyncze właściwości możemy 
            przekazywać bądź przy pomocy predefiniowanych słowników <i>ViewData</i> i <i>TempData</i>, bądź poprzez opakowujący właściwość ViewData dynamiczny
            obiekt ViewBag:<br/><br/>
            <code>
            Kontroler:<br/>
            ViewData[""title""] = book.Title;<br/>
            ViewData[""price""] = book.Price;<br/><br/>
            Widok:<br/>
            &lt;h1&gt;@ViewData[""title""]&lt;/h1&gt;<br/>
            &lt;h1&gt;@ViewData[""price""]&lt;/h1&gt;<br/>
            <br/>
            Kontroler:<br/>
            ViewBag.title = book.Title;<br/>
            ViewBag.price = book.Price;<br/><br/>
            Widok:<br/>
            &lt;h1&gt;@ViewBag.title&lt;/h1&gt;<br/>
            &lt;h1&gt;@ViewBag.price&lt;/h1&gt;<br/>
            </code>
            <br/>
            Kolejna możliwość to odwołanie się do właściwości Model słownika ViewData:<br/><br/>
            <code>
            Kontroler:<br/>
            return View(""BookInfo"", book);<br/><br/>
            Widok:<br/>
            @{ var book = (Book)ViewData.Model; }<br/>
            &lt;h1&gt;@book.title&lt;/h1&gt;<br/>
            &lt;h1&gt;@book.price&lt;/h1&gt;<br/>            
            </code>
            <br/>
            Jeżeli zależy nam na statycznym określeniu typu modelu wykorzystywanego w widoku (co przy okazji umożliwia nam korzystanie z dobrodziejstw
            mechanizmu Intellisense podczas tworzenia widoku), musimy posłużyć się inną metodą, opartą na słowie kluczowym @model:<br/><br/>
            <code>            
            Kontroler: jak w poprzednim przykładzie<br/><br/>
            Widok:<br/>
            @model Book<br/><br/>
            &lt;h1&gt;@Model.title&lt;/h1&gt;<br/>
            &lt;h1&gt;@Model.price&lt;/h1&gt;<br/>            
            </code>
            ");
            test = new Test(s5.Name, 1, TestType.Static);
            test.TestQuizzes = new List<Quiz>();
            test.TestQuizzes.Add(new Quiz(1, "Pytanie o składnię Razor", "Który fragment kodu napisany został w składni Razor?",
                                                new List<Answer>() { new Answer("A", "&lt;% foreach(val book in books) { %&gt;", false),
                                                new Answer("B", "@foreach(val book in books) {", true) }
                                          )
                                );
            test.TestQuizzes.Add(new Quiz(2, "Pytanie o słowniki danych", "Która z poniższych nazw jest nazwą słownika służącego do przekazywania danych z kontrolera do widoku?",
                                                new List<Answer>() { new Answer("A", "ViewBag", false), 
                                                new Answer("B", "ViewTemp", true), 
                                                new Answer("C", "ViewData", false) }
                                          )
                                );
            test.TestQuizzes.Add(new Quiz(3, "Pytanie o przkazywanie danych", "Który sposób przekazania modelu do widoku umożliwia posługiwanie się mechanizmem Intellisense w edycji widoku?",
                                                new List<Answer>() { new Answer("A", "@{ var book = (Book)ViewData.Model; }", false), 
                                                new Answer("B", "@model Book", true) }
                                          )
                                );
            s5.SubjectTest = test;
            s5.SubjectMaterials.Add(mt);
            Subject s6 = new Subject(6, 6, "Modele");
            mt = new Material(1, "", "", @"
            Modele są zazwyczaj klasami C#, które udostępniają dane obiektów w formie właściwości, a ich logikę biznesową w formie metod.
            Przykładowa klasa modelu książki w aplikacji MVC może wyglądać następująco:<br/><br/>
            <code>
            public class Book {<br/>
            &nbsp;&nbsp;public long Id { get; set; }<br/>
            &nbsp;&nbsp;public String Title { get; set; }<br/>
            &nbsp;&nbsp;public String Author { get; set; }<br/>
            &nbsp;&nbsp;public String Publisher { get; set; }<br/>
            &nbsp;&nbsp;public int PublishingYear { get; set; }<br/>
            &nbsp;&nbsp;public int Pages { get; set; }<br/>
            }<br/>
            </code>
            ");
            s6.SubjectMaterials = new List<MaterialBase>() { mt };
            Subject s7 = new Subject(7, 7, "Uwierzytelnianie");
            mt = new Material(1, "", "", @"
            Prostym sposobem na wymusznie uwierzytelniania użytkownika na poziomie poszczególnych akcji kontrolerów jest zastosowanie atrybutu
            <i>AuthorizedAttribute</i>. Jest to przy okazji przykład wykorzystania tzw. programowania aspektowego w ASP.NET MVC:<br/><br/>
            <code>
            public class AccountController<br/>
            {<br/>
            &nbsp;&nbsp;[Authorize]<br/>
            &nbsp;&nbsp;public ActionResult Edit(ind id) {<br/>
            &nbsp;&nbsp;{<br/>
            &nbsp;&nbsp;&nbsp;&nbsp;var account = _repository.GetAccountById(id);<br/>
            &nbsp;&nbsp;&nbsp;&nbsp;return View(""Account"", account);<br/>
            &nbsp;&nbsp;}<br/>
            }<br/>
            </code>
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