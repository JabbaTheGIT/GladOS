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
    public class CreatePersonViewModel : MvxViewModel
    {
        private readonly IPersonInfoDatabase personDb;
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

        private string name = "";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string number = "";

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        private string email = "";

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string employer = "";

        public string Employer
        {
            get { return employer; }
            set { employer = value; }
        }

        public List<Person> People { get; set; }

        public ICommand UploadDetails { get; private set; }

        public bool CheckDetailsPerson(IDialogService dialog)
        {
            if(Name == "" || Name == null)
            {
                dialog.Show("Please enter a Name", "Name required");
                return false;
            }
            if(Number == "" || Number == null)
            {
                dialog.Show("Please enter a contact Number", "Contact Number Required");
                return false;
            }
            if (Email == "" || Email == null)
            {
                dialog.Show("Please enter a contact Email", "Contact Email Required");
                return false;
            }
            if (Employer == "" || Employer == null)
            {
                dialog.Show("Please enter a Employer", "Employer Required");
                return false;
            }
            return true;
        }

        public async void SyncWithDb(Person person)
        {
            await personDb.InsertPerson(person);
        }

        public async void GetAllPeople()
        {
            bool found = false;
            var people = await personDb.GetPersons();
            if(people.Count() > 0)
            {
                foreach(var person in people)
                {
                    if(found == false && person.Name == Name && person.Email == Email)
                    {
                        SyncWithGlobal(person);    
                    }
                }
            }
            IsBusy = false;
            ShowViewModel<PublishLocationViewModel>();
        }

        public void SyncWithGlobal(Person person)
        {
            GlobalLocalPerson.Id = person.id;
            GlobalLocalPerson.Name = person.Name;
            GlobalLocalPerson.Email = person.Email;
            GlobalLocalPerson.Employer = person.Employer;
            GlobalLocalPerson.Number = person.Number;
        }

        public CreatePersonViewModel(IDialogService dialog, IPersonInfoDatabase personDb)
        {
            this.personDb = personDb;
            this.dialog = dialog;

            UploadDetails = new MvxCommand(() =>
            {
                Person upload = new Person();
                bool test = CheckDetailsPerson(dialog);

                if(test)
                {
                    IsBusy = true;
                    upload.Name = Name;
                    upload.Number = Number;
                    upload.Email = Email;
                    upload.Employer = Employer;
                    upload.Contactable = true;
                    SyncWithDb(upload);
                    GetAllPeople();
                }
            });

        }//End ProfileViewModel

    }
}
