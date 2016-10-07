using GladOS.Core.Models;
using GladOS.Core.Services;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Linq;
using GladOS.Core.Interfaces;
using GladOS.Core.Database;

/*This view show all the people in the database, will update to show only searched 
 *for people
 */

namespace GladOS.Core.ViewModels
{
    public class SearchViewModel : MvxViewModel
    {

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

            SearchPressed = new MvxCommand(() =>
            {
                base.ShowViewModel<SearchViewModel>();
            });

            SelectedPerson = new MvxCommand<Person>(selectedPerson => 
                             base.ShowViewModel<SelectedIndividualViewModel>(selectedPerson));

            GetPeople(personDb);
            
        }//EndThirdViewModel

        public ICommand HomePressed { get; private set; }
        public ICommand SchedulePressed { get; private set; }
        public ICommand SearchPressed { get; private set; }
        public ICommand SelectedPerson { get; private set; }

        private readonly IPersonInfoDatabase personDb;

        private List<Person> persons;
        public List<Person> Persons
        {
            get { return persons; }
            set { persons = value; RaisePropertyChanged(() => Persons); }
        }

        public async void GetPeople(IPersonInfoDatabase personDb)
        {
            var newList = new List<Person>();
            PersonProperties personProperties = new PersonProperties();
            var personInfo = await personDb.GetPersons();
            foreach (var person in personInfo)
            {
                Person newPerson = new Person();
                newPerson = personProperties.CreatePerson(person.Name, person.Number, "", person.Employer, person.Email);
                newList.Add(newPerson);
            }

            Persons = newList;
        }
    }
}