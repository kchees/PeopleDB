using System;
using System.Linq;
using PeopleDB.Models;

namespace PeopleDB
{
    static class UIHelper
    {
        public static void OutputTitle()
        {
            Console.WriteLine(Constants.Title);
            Console.WriteLine(string.Concat(Enumerable.Repeat("=", Constants.Title.Length)));
        }

        public static void OutputMenu()
        {
            Console.Clear();
            OutputTitle();

            Console.WriteLine("");
            // Console.WriteLine("");
        }

        public static void OutputOption(string title)
        {
            Console.Clear();
            Console.WriteLine(title);
            Console.WriteLine(string.Concat(Enumerable.Repeat("=", title.Length)));
            Console.WriteLine("");         
        }

        public static void AnyKey()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Press any key...");
            Console.ReadKey(true);
        }

        public static void OutputRecordCount(IOrderedQueryable<Person> query)
        {
            Console.WriteLine("");
            Console.WriteLine("{0} record(s) found", query.Count());
            AnyKey();
        }

        public static void OutputRecordsDeleted(int count)
        {
            Console.WriteLine("");
            Console.WriteLine("{0} record(s) deleted", count);
            AnyKey();
        }

        public static void OutputPerson(Person person)
        {
            Console.WriteLine("");
            Console.WriteLine("Name: {0}", person.Name);
            Console.WriteLine("Date Of Birth: {0}", person.DOB.ToShortDateString());
            Console.WriteLine("Address: {0}", person.Address);
            Console.WriteLine("Postcode: {0}", person.PostCode);
            Console.WriteLine("Phone: {0}", person.Phone);
            Console.WriteLine(string.Concat(Enumerable.Repeat("_", 80)));
        }

        public static string ReadText(string prompt)
        {
            Console.Write(prompt + " ");
            return Console.ReadLine().Trim();
        }

        public static DateTime ReadDate(string prompt)
        {
            DateTime date = DateTime.MinValue;

            Console.Write(prompt + " ");
            string[] temp = Console.ReadLine().Trim().Split('/');
            if (temp.Length == 3)
            {
                int day = Convert.ToInt32(temp[0]);
                int month = Convert.ToInt32(temp[1]);
                int year = Convert.ToInt32(temp[2]);

                date = new DateTime(year, month, day);
            }

            return date;
        }

        public static Boolean AreYouSure()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Are you sure (Y/N)? ");

            char key;
            do
            {
                key = Console.ReadKey(true).KeyChar;
            }
            while ((key != 'Y') && (key != 'y') && (key != 'N') && (key != 'n'));

            Console.Write(key);
            return ((key == 'Y') || (key == 'y'));
        }
    }
}
