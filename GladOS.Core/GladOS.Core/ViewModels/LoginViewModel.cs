using gladOS.Core.Models;
using gladOS.Core.Services;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Linq;
using gladOS.Core.Interfaces;
using gladOS.Core.Database;
using System;

namespace gladOS.Core.ViewModels
{
    public class LoginViewModel 
        : MvxViewModel
    {
        private readonly IPersonInfoDatabase personDb;
        
        private List<PersonInfo> People { get; set; }
        public string SearchName { get; set; }

        private bool isBusy = true;

        public bool IsBusy
        {
            get { return isBusy; }

            set
            {
                isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }


        public ICommand LoginPressed { get; private set; }
        public ICommand CreatePerson { get; private set; }

        public void GetPerson(List<PersonInfo> people, string searchName)
        {
            bool found = false;

            if(people.Count() > 0)
            {
                foreach (PersonInfo person in people)
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
        }

        public async void GetAllPeople(IPersonInfoDatabase persDb)
        {
            var newList = new List<PersonInfo>();
            PersonProperties personProperties = new PersonProperties();
            var people = await personDb.GetPersons();
            if(people.Count() > 0)
            {
                foreach(var person in people)
                {
                    PersonInfo newPerson = new PersonInfo();
                    newPerson = personProperties.CreatePerson(person.id, person.Name, person.Number, person.Employer, 
                                                              person.Email, person.Latitude, person.Longitude, person.Contactable);
                    newList.Add(newPerson);
                }
                People = newList;
                IsBusy = false;
            }
        }

        public LoginViewModel(IPersonInfoDatabase personDb)
        {
            this.personDb = personDb;
            GetAllPeople(personDb);

            LoginPressed = new MvxCommand(() =>
            {
                if (isBusy == false)
                {
                    if (SearchName == null || SearchName == "")
                    {
                        GetPerson(People, "Bruce Wayne");
                        base.ShowViewModel<HomeViewModel>();
                    }
                    else
                    {
                        GetPerson(People, SearchName);
                        base.ShowViewModel<HomeViewModel>();
                    }
                }
            });

            CreatePerson = new MvxCommand(() =>
            {
                ShowViewModel<CreatePersonViewModel>();
            });
        }

    }
}
