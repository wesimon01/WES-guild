using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models;
using DVDLibrary.Data;


namespace DVDSQLConsole.cs
{
    public class Program
    {
        static void Main(string[] args)
        {


            LoadAllDVDS();
            //LoadSingleDVD();
            Console.ReadLine();

        }

            private static void LoadSingleDVD()
        {
            DVDSQLRepository repo = new DVDSQLRepository();
            DVD dvd = repo.Get(3);

            Console.WriteLine(dvd.Id);
            Console.WriteLine(dvd.Title);
            Console.WriteLine(dvd.ReleaseDate.ToString("MM/dd/yyyy"));
            Console.WriteLine(dvd.MPAARating.ToString());
            Console.WriteLine(dvd.DirectorName);
            Console.WriteLine(dvd.Studio);
            Console.WriteLine(dvd.UserRating);
            Console.WriteLine(dvd.UserNotes);   
            Console.WriteLine(dvd.ActorsInMovie);

        }

        private static void LoadAllDVDS()
        {
            DVDSQLRepository repo = new DVDSQLRepository();

            Console.WriteLine("All DVDS");
            Console.WriteLine("-------------");
            foreach (DVD d in repo.GetAll())
            {
                Console.WriteLine("{0:D2} {1,-17} {2} {3:d}", d.Id, d.Title + ", " + d.ReleaseDate.ToString("MM/dd/yyyy"), d.MPAARating.ToString(), d.DirectorName);
            }



        }
        


    }
    }

