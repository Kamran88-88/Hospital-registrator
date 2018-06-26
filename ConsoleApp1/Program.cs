using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            User user = new User();
            controller.Doctorlist();
            controller.SectorList();
            //Hospital hospital = new Hospital() { sectors = controller.Allsectors };
            user.AddInfo();
            Console.WriteLine();
            Console.WriteLine("Shobeni sechin(1,2,3):");
            controller.ShowSectors();
            controller.SerchSector();
            Console.Clear();
            Console.WriteLine("Hekimi sechin:");
             controller.ShowSecDoctor();
            controller.SerchSecDoctor();

            controller.SerchTime();
        }
    }



    class Doctor
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Experience { get; set; }
        public string[] ReceptionHours { get; set; }

    }

    class Sector
    {
        public string Name { get; set; }
        public List<Doctor> doctors { get; set; }


    }

    class Hospital
    {
        public List<Sector> sectors { get; set; }

    }

    class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public void AddInfo()
        {
            User user = new User();
            Console.Write("Ad:");
            user.Name = Console.ReadLine();
            Console.Write("Soyad:");
            user.Surname = Console.ReadLine();
            Console.Write("Email:");
            user.Email = Console.ReadLine();
            Console.Write("Telefon No:");
            user.Phone = Console.ReadLine();
        }
    }

    class Controller
    {
        int SectorRow = 0;
        int TimeCount = 0;
        int DocSerch = 0;
        Hospital hospital;
        Sector sector;
        public List<Doctor> doctors { get; set; }
        public List<Sector> Allsectors { get; set; }
        public Controller()
        {
            hospital = new Hospital();
            sector = new Sector();
         
        }

        public void Doctorlist()
        {
            doctors = new List<Doctor>()
            {
                new Doctor(){Name="Kamran",Surname="Aliyev",Experience=12,ReceptionHours=new string[3]{"09:00-11:00", "11:00-13:00", "14:00-16:00" } },
                new Doctor(){Name="Orxan",Surname="Hasanov",Experience=3,ReceptionHours=new string[3]{"07:00-09:00", "10:00-12:00", "13:00-15:00" }},
                new Doctor(){Name="Alim",Surname="Salehzade",Experience=4,ReceptionHours=new string[3]{"09:00-11:00", "15:00-17:00", "19:00-21:00" }},
                new Doctor(){Name="Kenan",Surname="Shefisoy",Experience=12,ReceptionHours=new string[3]{"08:30-10:00", "12:30-15:20", "16:20-18:20" }},
                new Doctor(){Name="Farhad",Surname="Hacinsi",Experience=5,ReceptionHours=new string[3]{"09:00-11:00", "11:00-13:00", "14:00-16:00" }},
                new Doctor(){Name="Fizuli",Surname="Qurbanov",Experience=6,ReceptionHours=new string[3]{"08:30-10:00", "12:30-15:20", "16:20-18:20" }},
                new Doctor(){Name="Teymur",Surname="Aliyev",Experience=12,ReceptionHours=new string[3]{"10:00-12:00", "13:00-15:00", "15:00-17:00" }},
                new Doctor(){Name="Murad",Surname="Heyderov",Experience=7,ReceptionHours=new string[3]{"09:00-11:00", "12:00-15:00", "15:30-17:30" }},
                new Doctor(){Name="Arzu",Surname="Nezerova",Experience=3,ReceptionHours=new string[3]{"09:00-11:00", "15:00-17:00", "19:00-21:00" }},
            };
        }

        public void SectorList()
        {
              Allsectors = new List<Sector>
            {
                new Sector(){Name="1. Pediatriya",doctors= new List<Doctor>{doctors[0], doctors[1]}  },
                new Sector(){Name="2. Travmatologiya",doctors= new List<Doctor>{ doctors[2], doctors[3], doctors[4], doctors[5] }},
                new Sector(){Name="3. Stamotologiya",doctors= new List<Doctor>{ doctors[6], doctors[7], doctors[8] }}
            };
        }

        public void ShowSectors()
        {
            foreach (var item in Allsectors)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void SerchSector()
        {
            //int serchSec;
            do
            {
                SectorRow = Convert.ToInt32(Console.ReadLine());
                SectorRow--;
            } while (SectorRow < 0 || SectorRow > Allsectors.Count - 1); //burada hele try catch de yazilmalidr ki string qebul edende sehv vermesin
            sector = Allsectors[SectorRow];
           
        }

        public void ShowSecDoctor()
        {
            Console.WriteLine($"{sector.Name} shobesi");
            int DocCount = 0;
            foreach (var item in sector.doctors)
            {
                Console.WriteLine($"{++DocCount} {item.Name} {item.Surname}. Qebul saatlari:");
                TimeCount = 0;
                foreach (var hours in item.ReceptionHours)
                {
                    Console.WriteLine($"--{++TimeCount}. {hours}");
                }
                Console.WriteLine();
            }
        }

        public void SerchSecDoctor()
        {
            do
            {
                DocSerch = Convert.ToInt32(Console.ReadLine());
                DocSerch--;
            } while (DocSerch < 0 || DocSerch + 1 > sector.doctors.Count);//burada hele try catch de yazilmalidr ki string qebul edende sehv vermesin

        }

        public void SerchTime()
        {
         

            Console.Clear();
            Console.WriteLine($"{sector.doctors[DocSerch].Name} {sector.doctors[DocSerch].Surname }");
            TimeCount = 0;
            foreach (var hours in sector.doctors[DocSerch].ReceptionHours)
            {
                Console.WriteLine($"--{++TimeCount}. {hours}");
            }
            Console.WriteLine();
            Console.WriteLine("Qebul saatini sechin");

            int TimeSerch = 0;


            do
            {
                TimeSerch = Convert.ToInt32(Console.ReadLine());

                TimeSerch--;
            } while (TimeSerch > sector.doctors[DocSerch].ReceptionHours.Length - 1); //string olarsa try catch da yaz

            Console.WriteLine(sector.doctors[DocSerch].ReceptionHours[TimeSerch]);

        }


    }

    
}