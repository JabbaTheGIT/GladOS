using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using MvvmCross.Core.ViewModels;

namespace gladOS.Core.Models
{
    public class Person
    {
        public Person() { }
        public Person(Person person)
        {
            Name = person.Name;
            Number = person.Number;
            Email = person.Employer;
            Employer = person.Employer;

        }
        //All the personal infomation about the person using the service
        [PrimaryKey, AutoIncrement]
        public string id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        //public string Photo { get; set; }
        public string Employer { get; set; }
        public string Email { get; set; }
        public bool Contactable { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }



}
