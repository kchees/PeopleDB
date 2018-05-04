using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleDB.Models;

namespace PeopleDB
{
    static class Program
    {     
        static void Main(string[] args)
        {
            Console.Title = Constants.Title;
            Console.ForegroundColor = ConsoleColor.Green;

            App theApp = new App();
            theApp.init();
            theApp.run();

           
            /*
            var query = from person in db.People orderby person.LastName select person;
            foreach (var person in query)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName);
            }


            Console.WriteLine("");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            */

        }


    }
}
