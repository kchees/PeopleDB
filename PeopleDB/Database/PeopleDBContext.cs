using System;
using System.Data.Entity;
using System.Collections.Generic;

namespace PeopleDB.Models
{
    public class PeopleDBContext : DbContext
    {
        public PeopleDBContext() : base("PeopleDB")
        {
            // Database.SetInitializer<PeopleDBContext>(new DropCreateDatabaseAlways<PeopleDBContext>());
            Database.SetInitializer<PeopleDBContext>(new CreateDatabaseIfNotExists<PeopleDBContext>());
        }

        // add a dummy set of people to the DB context
        public void init()
        {
            // clear all people first
            Clear();

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
                    Id = 2,
                    FirstName = "John", LastName = "Smith",
                    DOB = new DateTime(1982, 3, 5),
                    Address = "35 Redwood Glade, Leighton Buzzard, Beds.",
                    PostCode = "LU7 7JT",
                    Phone = "01525 669966"
                },
                new Person {
                    Id = 3,
                    FirstName = "Fred", LastName = "Johnson",
                    DOB = new DateTime(1974, 2, 20),
                    Address = "65 Limetree Grove, Leighton Buzzard, Beds.",
                    PostCode = "LU7 1KT",
                    Phone = "01525 346782"
                }
            };
            People.AddRange(people);

            // save the changes
            SaveChanges();
        }

        public void AddPerson(Person person)
        {
            People.Add(person);
            SaveChanges();
        }

        public void Clear()
        {
            foreach (var person in People)
            {
                People.Remove(person);
            }
            SaveChanges();
        }

        public DbSet<Person> People { get; set; }
    }
}
