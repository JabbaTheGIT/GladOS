using GladOS.Core.Database;
using GladOS.Core.Interfaces;
using GladOS.Core.Models;
using GladOS.Core.Services;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

/*This view holds the infomation about the local user, view enables them
 *to decide how they would like to be located and save that choice
 */
namespace GladOS.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private readonly IPersonInfoDatabase personDb;
        private readonly IDialogService dialog;

        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Employer { get; set; }




        public ICommand HomePressed { get; private set; }
        public ICommand SchedulePressed { get; private set; }
        public ICommand SearchPressed { get; private set; }
        public ICommand ProfilePressed { get; private set; }

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


        public void AssignHomePerson(List<Person> persons)
        {
            Person person = new Person();
            if (persons.Any())
            {
                person = persons.FirstOrDefault();
                this.Name = person.Name;
                this.Number = person.Number;
                this.Email = person.Email;
                this.Employer = person.Employer;
            }
            else
            {
                this.Name = "";
                this.Number = "";
                this.Email = "";
                this.Employer = "";
            }

        }

        public HomeViewModel(IPersonInfoDatabase personDb)
        {
            this.personDb = personDb;

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

            GetPeople(personDb);
            AssignHomePerson(persons);

        }//End SecondViewModel
    }
}
