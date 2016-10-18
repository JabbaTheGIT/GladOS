using GladOS.Core.Models;
using GladOS.Core.Services;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;

/*This view carries on from the search view, it displays the selected 
 * person chosen by the user from the search page
 */

namespace GladOS.Core.ViewModels
{
    public class SelectedIndividualViewModel : MvxViewModel
    {
        private Person selectedPerson;
        public ICommand ViewMap { get; private set; }

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

        private string image;

        public string Image
        {
            get { return image; }
            set { SetProperty(ref image, value); ; }
        }


        public void Init(Person parameters)
        {
            selectedPerson = parameters;

        }
        public override void Start()
        {
            base.Start();
            Name = selectedPerson.Name;
            Employer = selectedPerson.Employer;
            Email = selectedPerson.Email;
            PhoneNumber = selectedPerson.Number;
            GlobalSelectedPerson.Name = selectedPerson.Name;
            GlobalSelectedPerson.Number = selectedPerson.Number;
            GlobalSelectedPerson.Latitude = selectedPerson.Latitude;
            GlobalSelectedPerson.Longitude = selectedPerson.Longitude;
            //Image = selectedPerson.Photo;
            ViewMap = new MvxCommand(() =>
            {
                base.ShowViewModel<LocationViewModel>();
            });
        }
    }
}