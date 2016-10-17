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

/*This view holds the infomation about the local user, view enables them
 *to decide how they would like to be located and save that choice
 */
namespace GladOS.Core.ViewModels
{
    public class ProfileViewModel : MvxViewModel
    {
        private readonly IPersonInfoDatabase personDb;
        //private readonly ILocalPersonInfoDatabase localPersonDb;
        private readonly IDialogService dialog;

        public string Identify { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Employer { get; set; }
        public List<Person> People { get; set; }

        public ICommand HomePressed { get; private set; }
        public ICommand SchedulePressed { get; private set; }
        public ICommand SearchPressed { get; private set; }
        public ICommand ProfilePressed { get; private set; }
        public ICommand UpdatePerson { get; private set; }

        public void SyncWithGlobal()
        {
            this.Identify = GlobalLocalPerson.Id;
            if (Name == "" || Name == null)
            {
                this.Name = GlobalLocalPerson.Name;
            }
            if(Number == "" || Number == null)
            {
                this.Number = GlobalLocalPerson.Number;
            }
            if(Email == "" || Email == null)
            {
                this.Email = GlobalLocalPerson.Email;
            }
            if (Employer == "" || Employer == null)
            {
                this.Employer = GlobalLocalPerson.Employer;
            }
        }

        public async void UpdateGlobalValues(IPersonInfoDatabase persDb)
        {
            bool updated = false;
            var people = await personDb.GetPersons();
            if(people.Count() > 0)
            {
                foreach(var person in people)
                {
                    if(person.id == GlobalLocalPerson.Id && updated == false)
                    {
                        GlobalLocalPerson.Name = person.Name;
                        GlobalLocalPerson.Number = person.Number;
                        GlobalLocalPerson.Email = person.Email;
                        GlobalLocalPerson.Employer = person.Employer;
                        updated = true;
                    }
                }
            }

        }

        public async void UpdatedPerson(Person updatePerson)
        {
            await personDb.UpdatePerson(updatePerson);
        } //End UpdateddPerson

        public ProfileViewModel(IDialogService dialog, IPersonInfoDatabase personDb)
        {
            this.personDb = personDb;
            this.dialog = dialog;

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

            UpdatePerson = new MvxCommand(() =>
            {
                SyncWithGlobal();
                Person uPerson = new Person();
                uPerson.id = Identify;
                uPerson.Name = Name;
                uPerson.Number = Number;
                uPerson.Email = Email;
                uPerson.Employer = Employer;
                UpdatedPerson(uPerson);
                UpdateGlobalValues(personDb);
                base.ShowViewModel<ScheduleViewModel>();
            });

        }//End ProfileViewModel

    }
}
