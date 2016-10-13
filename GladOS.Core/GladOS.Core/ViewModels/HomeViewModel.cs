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

        private string name = "";

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        private string number = "";

        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                RaisePropertyChanged(() => Number);
            }
        }

        private string email = "";
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged(() => Email);
            }
        }

        private string employer = "";
        public string Employer
        {
            get { return employer; }
            set
            {
                employer = value;
                RaisePropertyChanged(() => Employer);
            }
        }

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
                newPerson = personProperties.CreatePerson(person.Name, person.Number, person.Employer, person.Email);
                newList.Add(newPerson);
            }

            Persons = newList;
        }


        public void AssignHomePerson(List<Person> persons)
        {
            Person person = new Person();
            if (persons.Count() != 0)
            {
                person = persons[0];
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

        }//End SecondViewModel
    }
}
