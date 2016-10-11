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
                Photo = "",
                Employer = "",
                Email = "",
                Nfc = false,
                Gps = false,
                Wifi = false,
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
                Nfc = false,
                Gps = false,
                Wifi = false,
                Bluetooth = false
            };
        }

        public Person CreatePerson(string name, string number, string employer, string email)
        {
            return new Person()
            {
                Name = name,
                Number = number,
                Employer = employer,
                Email = email

            };
        }

        public void SetBluetooth(Person person, int input)
        {
            if (input == 0)
            {
                person.Bluetooth = false;
            }
            else if (input == 1)
            {
                person.Bluetooth = true;
            }
        }

        public void SetWifi(Person person, int input)
        {
            if (input == 0)
            {
                person.Wifi = false;
            }
            else if (input == 1)
            {
                person.Wifi = true;
            }
        }

        public void SetGps(Person person, int input)
        {
            if (input == 0)
            {
                person.Gps = false;
            }
            else if (input == 1)
            {
                person.Gps = true;
            }
        }

        public void SetNfc(Person person, int input)
        {
            if (input == 0)
            {
                person.Nfc = false;
            }
            else if (input == 1)
            {
                person.Nfc = true;
            }
        }

        public void SetName(Person person,string name)
        {
            person.Name = name;
        }

        public void SetNumber(Person person, string number)
        {
            person.Number = number;
        }

        public void SetPhoto(Person person, string photo)
        {
            person.Photo = photo;
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
