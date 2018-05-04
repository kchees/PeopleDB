using System;
using System.Linq;
using PeopleDB.Models;
using PeopleDB.UI;

namespace PeopleDB
{
    public class App
    {
        private PeopleDBContext db;

        public void init()
        {
            UIHelper.OutputTitle();
            Console.WriteLine("Initializing...");

            // initialize database
            db = new PeopleDBContext();         
            // db.init();

            Console.Clear();
        }

        public void run()
        {
            Menu menu = new Menu();

            int option;
            do
            {
                option = menu.Show();
                Console.Write(option);
                doOption(option);
            }
            while (option != MenuCommand.Quit);

        }


        private void doOption(int option)
        {
            switch (option)
            {
                case MenuCommand.List:
                    list();
                    break;

                case MenuCommand.Search:
                    search();
                    break;

                case MenuCommand.AddUpdate:
                    addUpdate();
                    break;
                  
                case MenuCommand.Delete:
                    delete();
                    break;

                case MenuCommand.ClearAll:
                    clearAll();
                    break;

                case MenuCommand.ResetDB:
                    reset();
                    break;

                case MenuCommand.Quit:
                    quit();
                    break;

                default:
                    break;
            }
        }

        private void list()
        {
            UIHelper.OutputOption("LIST ALL PEOPLE");          

            var query = from person in db.People orderby person.LastName select person;
            foreach (var person in query)
            {
                Console.WriteLine(person.Name);
            }

            UIHelper.OutputRecordCount(query);
        }

        private void search()
        {
            UIHelper.OutputOption("SEARCH FOR PERSON");

            string name = UIHelper.ReadText("Name?");
            if (!string.IsNullOrEmpty(name))
            {
                IOrderedQueryable<Person> query;

                string[] temp = name.Split(' ');
                if (temp.Length == 2)
                {
                    string firstName = temp[0];
                    string lastName = temp[1];

                    query = from person in db.People
                            where ((person.FirstName == firstName) && (person.LastName == lastName))
                            orderby person.LastName
                            select person;
                }
                else
                {
                    query = from person in db.People
                            where ((person.FirstName == name) || (person.LastName == name))
                            orderby person.LastName
                            select person;
                }

                Console.WriteLine("");
                foreach (var person in query)
                {
                    UIHelper.OutputPerson(person);
                }

                UIHelper.OutputRecordCount(query);
            }
        }

        private void addUpdate()
        {
            UIHelper.OutputOption("ADD/UPDATE PERSON");

            Person newPerson = new Person();

            newPerson.FirstName = UIHelper.ReadText("First Name:");
            newPerson.LastName = UIHelper.ReadText("Last Name:");
            newPerson.DOB = UIHelper.ReadDate("Date Of Birth (DD/MM/YYYY): ");
            newPerson.Address = UIHelper.ReadText("Address:");
            newPerson.PostCode = UIHelper.ReadText("Postcode:");
            newPerson.Phone = UIHelper.ReadText("Phone:");
        
            var people = db.People.Where(p => (p.FirstName == newPerson.FirstName && p.LastName == newPerson.LastName)).ToList();
            if (people.Any())
            {
                people.ForEach(p =>
                    {
                        p.DOB = newPerson.DOB;
                        p.Address = newPerson.Address;
                        p.PostCode = newPerson.PostCode;
                        p.Phone = newPerson.Phone;
                    }
                );
                db.SaveChanges();
            }
            else
            {
                db.AddPerson(newPerson);
            }
            
            UIHelper.AnyKey();
        }

        private void delete()
        {
            UIHelper.OutputOption("DELETE PERSON");

            Person newPerson = new Person();

            string firstName = UIHelper.ReadText("First Name:");
            string lastName = UIHelper.ReadText("Last Name:");

            int count = 0;
            var people = db.People.Where(p => (p.FirstName == firstName && p.LastName == lastName));
            if (people.Any())
            {
                count = people.Count();

                db.People.RemoveRange(people);
                db.SaveChanges();           
            }

            UIHelper.OutputRecordsDeleted(count);
        }

        private void clearAll()
        {
            if (UIHelper.AreYouSure())
            {
                Console.Clear();
                UIHelper.OutputTitle();
                Console.WriteLine("Clearing database...");

                db.Clear();       
            }
        }

        private void reset()
        {
            if (UIHelper.AreYouSure())
            {
                Console.Clear();
                UIHelper.OutputTitle();
                Console.WriteLine("Resetting database...");

                db.Clear();
                db.init();
            }
        }

        private void quit()
        {
            Console.Clear();
            UIHelper.OutputTitle();
            Console.WriteLine("Quitting...");
        }
    }
}
