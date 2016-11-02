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

/*This view holds the infomation about the local user, view enables them
 *to decide how they would like to be located and save that choice
 */
namespace gladOS.Core.ViewModels
{
    public class ProfileViewModel : MvxViewModel
    {
        private readonly IPersonInfoDatabase personDb;
        //private readonly ILocalPersonInfoDatabase localPersonDb;
        private readonly IDialogService dialog;

        private bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }

            set
            {
                isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public string Identify { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Employer { get; set; }
        public List<PersonInfo> People { get; set; }

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

        public async void UpdatedPerson(PersonInfo updatePerson)
        {
            IsBusy = true;
            await personDb.UpdatePerson(updatePerson);
            IsBusy = false;
            ShowViewModel<HomeViewModel>();
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
                PersonInfo uPerson = new PersonInfo();
                uPerson.id = Identify;
                uPerson.Name = Name;
                uPerson.Number = Number;
                uPerson.Email = Email;
                uPerson.Employer = Employer;
                UpdatedPerson(uPerson);
                UpdateGlobalValues(personDb);
            });

        }//End ProfileViewModel

    }
}
