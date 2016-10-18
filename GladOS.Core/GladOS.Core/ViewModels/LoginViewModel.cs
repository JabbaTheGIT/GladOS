//William Gwilt n9425438
//NSC Industries prject GladOS

using GladOS.Core.Models;
using GladOS.Core.Services;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Linq;
using GladOS.Core.Interfaces;
using GladOS.Core.Database;
using System;

namespace GladOS.Core.ViewModels
{
    public class LoginViewModel 
        : MvxViewModel
    {
        private readonly IPersonInfoDatabase personDb;
        
        private List<Person> People { get; set; }
        public string SearchName { get; set; }

        public ICommand LoginPressed { get; private set; }

        public void GetPerson(List<Person> people, string searchName)
        {
            bool found = false;

            if(people.Count() > 0)
            {
                foreach (Person person in people)
                {
                    //Find the searched person and assign him/her to the Global Person
                    if (person.Name.ToUpper() == searchName.ToUpper() && found == false)
                    {
                        GlobalLocalPerson.Id = person.id;
                        GlobalLocalPerson.Name = person.Name;
                        GlobalLocalPerson.Number = person.Number;
                        GlobalLocalPerson.Email = person.Email;
                        GlobalLocalPerson.Employer = person.Employer;
                        GlobalLocalPerson.Latitude = person.Latitude;
                        GlobalLocalPerson.Longitude = person.Longitude;
                        found = true;
                    }
                }
            }
            // Person not in Db load a deafult for now
            if(found == false)
            {
                DefaultPerson();
            }
        }

        private void DefaultPerson()
        {
            GlobalLocalPerson.Id = "1d585760-c31b-40a2-aa73-4210d343d738";
            GlobalLocalPerson.Name = "Bruce Wayne";
            GlobalLocalPerson.Number = "0404889911";
            GlobalLocalPerson.Email = "darkKnight@telstra.com";
            GlobalLocalPerson.Employer = "Telstra";
            GlobalLocalPerson.Latitude = -27.4735519;
            GlobalLocalPerson.Longitude = 153.025281;
        }

        public async void GetAllPeople(IPersonInfoDatabase persDb)
        {
            var newList = new List<Person>();
            PersonProperties personProperties = new PersonProperties();
            var people = await personDb.GetPersons();
            if(people.Count() > 0)
            {
                foreach(var person in people)
                {
                    Person newPerson = new Person();
                    newPerson = personProperties.CreatePerson(person.id, person.Name, person.Number, person.Employer, 
                                                              person.Email, person.Latitude, person.Longitude);
                    newList.Add(newPerson);
                }
                People = newList;
            }
        }

        public LoginViewModel(IPersonInfoDatabase personDb)
        {
            this.personDb = personDb;
            GetAllPeople(personDb);

            LoginPressed = new MvxCommand(() =>
            {
                if(SearchName == null || SearchName == "")
                {
                    DefaultPerson();
                    base.ShowViewModel<HomeViewModel>();
                }
                else
                {
                    GetPerson(People, SearchName);
                    base.ShowViewModel<HomeViewModel>();
                }
            });
        }

    }
}
