

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller.SignSerch();

            Console.Clear();


        }
    }



    class Person
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }

    class Worker : Person
    {
        public CV cv { get; set; }

    }
    class Employer : Person
    {
    }

    class CV
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Gender { get; set; }
        public int Education { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public int Category { get; set; }
        public int City { get; set; }
        public int Salary { get; set; }
        public string Phone { get; set; }
    }

    static class Controller
    {
        static string input = null;
        static Person person = null;
        static bool Trueform = false;
        static List<Person> workers = new List<Person>();
        static List<Person> employers = new List<Person>();
        static bool firsRegistr = true;
        static CV Cv = new CV();


        static public void WorkOrEmploy()
        {

            do
            {
                Console.WriteLine("1. Worker");
                Console.WriteLine("2. Employer");

                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        person = new Worker();
                        break;
                    case "2": person = new Employer(); break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Sehv kod. Tekrar daxil et.");
                        Console.WriteLine();
                        break;
                }
            } while (input != "1" && input != "2");

        }

        static public void SignSerch()
        {
            string serch = null;
            while (serch != "4")
            {
                if (firsRegistr || serch == "3")
                {
                    Console.WriteLine("1. Sign In");
                    Console.WriteLine("2. Sign Up");
                }
                else
                {
                    Console.WriteLine("3. Return to main menu");
                }
                Console.WriteLine("4. Exit");

                serch = Console.ReadLine();

                switch (serch)
                {
                    case "1":
                        WorkOrEmploy();
                        SignIn(); break;
                    case "2":
                        WorkOrEmploy();
                        SignUp(); break;
                    case "3": Console.Clear(); break;
                    case "4":
                        Exit();
                        Environment.Exit(0);
                        break;
                    default: Console.WriteLine("Error! Try again"); break;
                }
            }
        }

        static public void SignIn()
        {
            if (firsRegistr)//ona gore lazimdir ki, bir neche useri qeydiyyatdan kechirib sonra hamisini bir yerde fayla yukleyerken proqram hemishe gedib fayli oxumasin. fayli bir defe oxuyur melumati ordan alir ve daha onu hech vaxt oxumur. Proqram bitenden sonra ise list ozunde yigdigi melumati yeniden fayla atir. Bir sozle bu if melumati fayldan bir defe oxumaq uchun lazimdir
            {
                Readfile();
                firsRegistr = false;
            }

            Person person2 = null;
            switch (input)
            {
                case "1": person2 = new Worker(); break;
                case "2": person2 = new Employer(); break;
            }
            Console.WriteLine("Email:");
            person2.Email = Console.ReadLine();
            Console.WriteLine("Password:");
            person2.Password = Console.ReadLine();
            // person2.Status = input;
            Person[] a = null;
            switch (input)
            {
                case "1": a = workers.Where(x => x.Email == person2.Email && x.Password == person2.Password).ToArray(); break;
                case "2": a = employers.Where(x => x.Email == person2.Email && x.Password == person2.Password).ToArray(); break;
            }


            foreach (var item in a)
            {
                Console.WriteLine($"{item.Username} xosh gelmisiz!");

                switch (input)
                {
                    case "1":
                        var cast = (Employer)item;
                        Cv = Create_CV();
                        // cast.cv = Cv;
                        break;

                        // case "2":
                }

                // Create_CV();

            }

        }

        static public void WorkerMenu()
        {
            Console.WriteLine("1. Create CV");
            Console.WriteLine("2. Find a job");
            Console.WriteLine("3. Serch");
            Console.WriteLine("4. Show all job ads");
            Console.WriteLine("5. Log out");
            var serch = Console.ReadLine();

            switch (serch)
            {
                case "1": Create_CV(); break;
                    //case "2": Find_Job(); break;
                    //case "3": Search(); break;
                    //case "4": Show_all_jobs(); break;
                    //case "5": Log_out(); break;
            }
        }

        static public CV Create_CV()
        {
            CV cv = new CV();
            Console.WriteLine("Name: ");
            cv.Name = Console.ReadLine();
            Console.WriteLine("Surname: ");
            cv.Surname = Console.ReadLine();
            Console.WriteLine("Gender:");
            Console.WriteLine("1. Man");
            Console.WriteLine("2. Woman");
            Console.WriteLine("3 Other");
            cv.Gender = Convert.ToInt32(Console.ReadLine());
            Console.Write("Age: ");
            cv.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Edication: ");
            Console.WriteLine("1. High");
            Console.WriteLine("2. Incomplete higher");
            Console.WriteLine("3. School education");
            cv.Education = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Job experience");
            Console.WriteLine("1. Less than 1 year");
            Console.WriteLine("2. Between 1 and 3 years");
            Console.WriteLine("3. Between 3 and 5 years");
            Console.WriteLine("4. 5 years and more");
            cv.Experience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Category:");
            Console.WriteLine("1. Doctor");
            Console.WriteLine("2. Driver");
            Console.WriteLine("3. It spesialist");
            Console.WriteLine("4. Translator");
            cv.Category = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("City:");
            Console.WriteLine("1. Baku");
            Console.WriteLine("2. Ganja");
            Console.WriteLine("3. Sumqayit");
            Console.WriteLine("4. Xirdalan");
            cv.City = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Salary:");
            cv.Salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Mobil phone:");
            string MobFormat = @"^(\+994)(50)|(51)|(55)|(70)|(77)(\d+){7}$";

            do
            {
                cv.Phone = Console.ReadLine();
                Trueform = Regex.IsMatch(cv.Phone, MobFormat);
                if (!Trueform)
                {
                    Console.WriteLine("Sehv format! Dogru varian misal: +99455xxxxxxx");
                }
            } while (!Trueform);

            return cv;
        }


        static public void EmployerMenu()
        {
            Console.WriteLine("1. Place an ad");
            Console.WriteLine("2. Find a worker");
            Console.WriteLine("3. Serch");
            Console.WriteLine("4. Appeals");
            Console.WriteLine("5. Log out");
        }


        static public void Readfile()
        {
            using (StreamReader read = new StreamReader("Workers.json"))
            {
                var fromWorkfile = JsonConvert.DeserializeObject<List<Person>>(read.ReadToEnd());
                workers = fromWorkfile;
            }

            using (StreamReader read1 = new StreamReader("Employers.json"))
            {
                var fromEmployFile = JsonConvert.DeserializeObject<List<Person>>(read1.ReadToEnd());
                employers = fromEmployFile;
            }
        }
        static public void Password()
        {
            string repass = null;
            do
            {
                if (repass != null)
                {
                    Console.WriteLine("Passwords don't match. Try again.");
                }
                Console.WriteLine("New password:");
                //--------------
                string passwordForm = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$"; //bir boyuk herf bir balaca bir reqem. 8-15 simvol arasi
                do
                {
                    person.Password = Console.ReadLine();
                    Trueform = Regex.IsMatch(person.Password, passwordForm);
                    if (!Trueform)
                    {
                        Console.WriteLine("Sehv format!");
                    }
                } while (!Trueform);

                Console.WriteLine("Please re-enter password");

                repass = Console.ReadLine();
            } while (repass != person.Password);
        }
        static public void SignUp()
        {
            if (firsRegistr)//ona gore lazimdir ki, bir neche useri qeydiyyatdan kechirib sonra hamisini bir yerde fayla yukleyerken proqram hemishe gedib fayli oxumasin. fayli bir defe oxuyur melumati ordan alir ve daha onu hech vaxt oxumur. Proqram bitenden sonra ise list ozunde yigdigi melumati yeniden fayla atir. Bir sozle bu if melumati fayldan bir defe oxumaq uchun lazimdir
            {
                Readfile();
                firsRegistr = false;
            }
            Console.WriteLine("User name:");
            person.Username = Console.ReadLine();
            Console.WriteLine("Email:");
            var mailformat = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

            do
            {
                person.Email = Console.ReadLine();
                Trueform = Regex.IsMatch(person.Email, mailformat);
                if (!Trueform)
                {
                    Console.WriteLine("Enter a correct format. Exp: muradheyderov@gmail.com");
                }
            } while (!Trueform);

            Password();

            person.Status = input;

            switch (input)
            {
                case "1": workers.Add(person); break;
                case "2": employers.Add(person); break;
            }
        }
        //--------------------------------------
        static public void Exit()
        {
            // if (people == null)
            //{
            var Workerjson = JsonConvert.SerializeObject(workers);
            var Employersjson = JsonConvert.SerializeObject(employers);

            using (StreamWriter writer1 = new StreamWriter("Workers.json"))
            {
                writer1.WriteLine(Workerjson);
            }
            using (StreamWriter writer = new StreamWriter("Employers.json"))
            {
                writer.WriteLine(Employersjson);
            }
        }
    }
}






//Bu proqram iscilerle is veren arasindaki elaqeni qurmaq ucundur.

// 1. Proqram sayesinde hem isciler hem de is verenler qeydiyyatdan kecir.Proqram acilan kimi sorusur Sign in, Sign up or Exit.Eger Sign up secilse asagidaki emeliyyatlar olur.

// 1.1 Isciler ve ya is verenler qeydiyyatdan kecdikleri zaman baslangic olaraq 
// - Username
// - Email (emailin formati regex le yoxlanilmalidir, format sehvdirse yeniden duzgun daxil etmesini istemelidir, Duzgun: muradheyderov @gmail.com)
// - Status: 1. Isci 2. Isveren
// - Sifre(
// -en azi bir boyuk herf olmalidir,
// -bir reqem, bir simvol (_+-/. ve s.) olamlidir, 
// -maksimum uzunluq 15 simvol, Duzgun: Murad_894
// )

// - tekrar password(yuxaridaki ile eyniliyi yoxlamaq ucun)
// - 4 simvoldan(reqem ve herf) ibaret random kod(bu kod random olaraq
//avtomatik yaradilacaq ve userden bu kodun eynisinin yazilmasini teleb edecek, Duzgun: w3Kp, 5Gq7)------------------//


// melumatlarini daxil edirler.

// 2. Eger isci kimi qeydiyyatdan kecibse esas menyuda bunlar gorsenecek



// 2.1. CV yerlesdir(Bu bolme secilen zaman asagidaki melumatlar elave olunmalidir)*****-----------------

// - Ad
// - Soyad
// - Cins(Kisi, Qadin)
// - Yas 
// - Tehsil(orta, natamam ali, ali)
// - Is tecrubesi
//{
// 1 ilden asagi,
// 1 ilden - 3 ile qeder
// 3 ilden - 5 ile qeder
// 5 ilden daha cox
//}
// - Kateqoriya(Evvelceden teyin olunur.Meselen, Hekim, Jurnalist, IT mutexessis, Tercumeci ve s.)
// - Seher(Baki, Gence, Seki ve s.)
// - Minimum emek haqqi 
// - Mobil telefon(+994 50/51/55/70/77 5555555(7) bu formati desteklemelidir)



// 2.1 Is axtar(CV melumatlarina gore)*********bunu worker kimi qeydiyyatdan kechen ve ya sign in olanlar gormelidir.

// 2.1. Isci bu bolmeni secdiyi zaman onun cv melumatlarina en cox uygun is elanlarini cixartmalidir.Eger isci elandaki sertleri odeyirse o elan gorsenmelidir.

// 2.2. Search

// 2.3.1. Yuxarida qeyd olunmus melumatlarin her hansi birine gore axtaris (Kateqoriya, Tehsil, Seher, Emek haqqi, Is tecrubesi)

// 2.4. Melumatlari goster

// - CV de daxil eledikleri melumatlari seliqeli sekilde gostermelidir.

// 2.5. Butun elanlari goster*********

// 2.5.1. Elanlarin adini gostermelidir.Meselen,

// {
// 1.Hekim

// 2.Jurnalist

// 3.Tercumeci

// ve s.


// Elanin reqemini secdiyimiz anda hemen is elaninin detallarini gostermelidir.

// }

//Secilen elanin sonunda

// - Muraciet et(y/n)

// olmalidir eger y secse elana muraciet etmelidir n secidiyi zaman ise yeniden butun elanlari gostermelidir.

// 2.6. Log out. (User in cixis edib birinci menyuya qayitmagi ucun)

// 2.7. Muraciet olunmus elanlar. (Muraciet elediyin butun elanlarin siyahisi ve statusu) // Inactive*******

// 2.8. Teklifler // Inactive

// 3. Eger is veren kimi qeydiyyatdan kecibse esas menyuda bunlar gorsenecek

// 3.1. Elan yerlesdir(Is veren bir nece elan yerlesdire biler) ******

// - Is elanin adi
// - Sirketin adi
// - Kateqoriya
// - Is barede melumat
// - Seher
// - Maas 
// - Yas
// - Tehsil(orta, natamam ali, ali)
// - Is tecrubesi
// - Mobil telefon(+994 50/51/55/70/77 5555555(7) bu formati desteklemelidir)

// 3.2 Isci axtar(CV melumatlarina gore) //Inactive*****

// 3.3 Search(Yuxarida qeyd olunmus melumatlarin her hansi birine gore axtaris (Kateqoriya, Tehsil, Seher, Emek haqqi, Is tecrubesi)) // Inactive

// 3.3. Muracietler(Bu bolmede is elanina edilen muracietler gorsenmelidir (Is elanin adi, Muraciet eden isci ve onun melumatlari))****

// 3.4. Log out. (User in cixis edib birinci menyuya qayitmagi ucun)

// 4. Proqram sonunda Exit secilen zaman butun isci ve is verenin melumatlini serialise ederek json ve ya xml formatinda fayla yazmaq lazimdir.Iscileri ayri fayla is vereni ise ayri fayla. Proqram ise dusen zaman da hemen melumatlari oxuyub proqrami qaldigi yerden davam etdirmek lazimdir.



