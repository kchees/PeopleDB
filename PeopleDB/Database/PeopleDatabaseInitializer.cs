using System;
using System.Data.Entity;
using System.Collections.Generic;

namespace PeopleDB.Models
{
    // public class PeopleDatabaseInitializer : DropCreateDatabaseAlways<PeopleDBContext> // re-creates every time the server starts
    public class PeopleDatabaseInitializer : IDatabaseInitializer<PeopleDBContext> // re-creates every time the server starts
    {
        public void InitializeDatabase(PeopleDBContext context)
        {
            if (context.Database.Exists())
            {
                if (!context.Database.CompatibleWithModel(true))
                {
                    context.Database.Delete();
                }
            }
            context.Database.Create();

            Seed(context);
        }

        // protected override void Seed(PeopleDBContext context)
        private void Seed(PeopleDBContext context)
        {
            // add a dummy set of people to the DB context
            IList<Person> people = new List<Person>()
            {
                new Person {
                    Id = 1,
                    FirstName = "Bob", LastName = "Wang",
                    DOB = new DateTime(1970, 1, 1),
                    Address = "123 Any Street, Milton Keynes, Bucks.",
                    PostCode = "MK41 2TJ",
                    Phone = "07885 246349"
                },
                new Person {
                    Id = 1,
                    FirstName = "John", LastName = "Smith",
                    DOB = new DateTime(1982, 3, 5),
                    Address = "35 Redwood Glade, Leighton Buzzard, Beds.",
                    PostCode = "LU7 7JT",
                    Phone = "01525 669966"
                },
                new Person {
                    Id = 1,
                    FirstName = "Fred", LastName = "Johnson",
                    DOB = new DateTime(1974, 2, 20),
                    Address = "65 Limetree Grove, Leighton Buzzard, Beds.",
                    PostCode = "LU7 1KT",
                    Phone = "01525 346782"
                }
            };
            // people.ForEach(person => context.People.Add(person));
            context.People.AddRange(people);

            // save the changes
            context.SaveChanges();     
        }
    }     
}
