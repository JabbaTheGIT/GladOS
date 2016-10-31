using gladOS.Core.Interfaces;
using gladOS.Core.Models;
using gladOS.Core.Services;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;

/*This view carries on from the search view, it displays the selected 
 * person chosen by the user from the search page
 */

namespace gladOS.Core.ViewModels
{
    public class SelectedIndividualViewModel : MvxViewModel
    {
        private PersonInfo selectedPerson;
        public ICommand ViewMap { get; private set; }
        public ICommand RequestInfo { get; private set; }


        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string employer;

        public string Employer
        {
            get { return employer; }
            set { SetProperty(ref employer, value); }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { SetProperty(ref phoneNumber, value); }
        }

        private bool contactable;

        public bool Contactable
        {
            get { return contactable; }
            set { SetProperty(ref contactable, value); }
        }

        private string image;

        public string Image
        {
            get { return image; }
            set { SetProperty(ref image, value); ; }
        }

        public void SyncGlobalPerson()
        {
            GlobalSelectedPerson.Name = selectedPerson.Name;
            GlobalSelectedPerson.Number = selectedPerson.Number;
            GlobalSelectedPerson.Contactable = selectedPerson.Contactable;
            GlobalSelectedPerson.Latitude = selectedPerson.Latitude;
            GlobalSelectedPerson.Longitude = selectedPerson.Longitude;
        }

        public void InitialiseVars()
        {
            Name = selectedPerson.Name;
            Employer = selectedPerson.Employer;
            Email = selectedPerson.Email;
            PhoneNumber = selectedPerson.Number;
            Contactable = selectedPerson.Contactable;
        }

        public void Init(PersonInfo parameters)
        {
            selectedPerson = parameters;
        }
        public override void Start()
        {
            base.Start();
            InitialiseVars();
            SyncGlobalPerson();

            ViewMap = new MvxCommand(() =>
            {
                if(contactable)
                {
                    ShowViewModel<LocationViewModel>();
                }              
            });

            RequestInfo = new MvxCommand(() =>
            {
                ShowViewModel<RequestInfomationViewModel>();
            });
        }

    }
}