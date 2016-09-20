using GladOS.Core.Models;


namespace GladOS.Core.Services
{
    public class PersonServices : Person
    {
        public Person CreatePerson()
        {
            return new Person()
            {
                Name = "",
                Number = "",
                Photo = "",
                Employer = "",
                Email = "",
                NFC = false,
                GPS = false,
                WiFi = false,
                Bluetooth = false
            };
        }

        public Person CreatePerson(string name, string number, string picture, string employer,
                                   string email)
        {
            return new Person()
            {
                Name = name,
                Number = number,
                Photo = picture,
                Employer = employer,
                Email = email,
                NFC = false,
                GPS = false,
                WiFi = false,
                Bluetooth = false
            };
        }

        public Person CreatePerson(string name, string number, string picture)
        {
            return new Person()
            {
                Name = name,
                Number = number,
                Photo = picture

            };
        }


    }
}
