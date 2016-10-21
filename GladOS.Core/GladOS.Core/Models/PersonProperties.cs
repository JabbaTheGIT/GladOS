using System;
using GladOS.Core.Models;


namespace GladOS.Core.Services
{
    public class PersonProperties : IPersonProperties
    {

        public Person CreatePerson()
        {
            return new Person()
            {
                Name = "",
                Number = "",
                Employer = "",
                Email = "",
            };
        }

        public Person CreatePerson(string name, string number,  string employer,
                                   string email)
        {
            return new Person()
            {
                Name = name,
                Number = number,
                Employer = employer,
                Email = email,
            };
        }

        public Person CreatePerson(string inputId, string name, string number, string employer,
                           string email)
        {
            return new Person()
            {
                id = inputId,
                Name = name,
                Number = number,
                Employer = employer,
                Email = email,
            };
        }

        public Person CreatePerson(string inputId, string name, string number, string employer, string email, double latitude, double longitude)
        {
            return new Person()
            {
                id = inputId,
                Name = name,
                Number = number,
                Employer = employer,
                Email = email,
                Latitude = latitude,
                Longitude = longitude
            };
        }

        public Person CreatePerson(string inputId, string name, string number, string employer, string email, double latitude, double longitude, bool contactable)
        {
            return new Person()
            {
                id = inputId,
                Name = name,
                Number = number,
                Employer = employer,
                Email = email,
                Latitude = latitude,
                Longitude = longitude,
                Contactable = contactable
            };
        }

        public void SetName(Person person,string name)
        {
            person.Name = name;
        }

        public void SetNumber(Person person, string number)
        {
            person.Number = number;
        }

        public void SetEmployer(Person person, string employer)
        {
            person.Employer = employer;
        }

        public void SetEmail(Person person, string email)
        {
            person.Email = email;
        }

    }
}
