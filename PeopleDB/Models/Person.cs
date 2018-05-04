using System;

namespace PeopleDB.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name
        {
            get { return string.Format("{0} {1}", FirstName, LastName);  }
        }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
    }
}
