using System;
using gladOS.Core.Models;


namespace gladOS.Core.Services
{
    public class PersonProperties : IPersonProperties
    {

        public PersonInfo CreatePerson()
        {
            return new PersonInfo()
            {
                Name = "",
                Number = "",
                Employer = "",
                Email = "",
            };
        }

        public PersonInfo CreatePerson(string name, string number,  string employer,
                                   string email)
        {
            return new PersonInfo()
            {
                Name = name,
                Number = number,
                Employer = employer,
                Email = email,
            };
        }

        public PersonInfo CreatePerson(string inputId, string name, string number, string employer,
                           string email)
        {
            return new PersonInfo()
            {
                id = inputId,
                Name = name,
                Number = number,
                Employer = employer,
                Email = email,
            };
        }

        public PersonInfo CreatePerson(string inputId, string name, string number, string employer, string email, double latitude, double longitude)
        {
            return new PersonInfo()
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

        public PersonInfo CreatePerson(string inputId, string name, string number, string employer, string email, double latitude, double longitude, bool contactable)
        {
            return new PersonInfo()
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

        public void SetName(PersonInfo person,string name)
        {
            person.Name = name;
        }

        public void SetNumber(PersonInfo person, string number)
        {
            person.Number = number;
        }

        public void SetEmployer(PersonInfo person, string employer)
        {
            person.Employer = employer;
        }

        public void SetEmail(PersonInfo person, string email)
        {
            person.Email = email;
        }

    }
}
