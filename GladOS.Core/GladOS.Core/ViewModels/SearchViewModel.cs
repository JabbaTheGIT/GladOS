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

/*This view show all the people in the database, will update to show only searched 
 *for people
 */

namespace GladOS.Core.ViewModels
{
    public class SearchViewModel : MvxViewModel
    {
        private string searchName = "";
        public string SearchName
        {
            get { return searchName; }
            set { searchName = value; RaisePropertyChanged(() => SearchName); }
        }

        public SearchViewModel(IPersonInfoDatabase personDb)
        {
            this.personDb = personDb;
            //Nav buttons
            HomePressed = new MvxCommand(() =>
            {
                base.ShowViewModel<HomeViewModel>();
            });

            SchedulePressed = new MvxCommand(() =>
            {
                base.ShowViewModel<ScheduleViewModel>();
            });

            ProfilePressed = new MvxCommand(() =>
            {
                base.ShowViewModel<ProfileViewModel>();
            });

            SearchPressed = new MvxCommand(() =>
            {
                base.ShowViewModel<SearchViewModel>();
            });

            SearchPerson = new MvxCommand(() =>
            {
                GetPeople(personDb, SearchName);
            });
                                    
            SelectedPerson = new MvxCommand<Person>(selectedPerson => 
                             base.ShowViewModel<SelectedIndividualViewModel>(selectedPerson));
      
        }//EndSearchViewModel

        public ICommand HomePressed { get; private set; }
        public ICommand SchedulePressed { get; private set; }
        public ICommand SearchPressed { get; private set; }
        public ICommand ProfilePressed { get;  private set;}
        public ICommand SelectedPerson { get; private set; }
        public ICommand SearchPerson { get; private set; }

        private readonly IPersonInfoDatabase personDb;

        private List<Person> persons;
        public List<Person> Persons
        {
            get { return persons; }
            set { persons = value; RaisePropertyChanged(() => Persons); }
        }

        public async void GetPeople(IPersonInfoDatabase personDb, string searchName)
        {
            var newList = new List<Person>();
            PersonProperties personProperties = new PersonProperties();
            var personInfo = await personDb.GetPersons();
            if(personInfo.Count() > 0)
            {
                foreach (var person in personInfo)
                {
                    if (person.Name.Contains(SearchName.ToLower()) || person.Name.Contains(SearchName.ToUpper()))
                    {
                        Person newPerson = new Person();
                        newPerson = personProperties.CreatePerson(person.id, person.Name, person.Number, person.Employer, 
                                                                  person.Email, person.Latitude, person.Longitude, person.Contactable);
                        newList.Add(newPerson);
                    }
                }
                Persons = newList;
            }
        }
    }
}