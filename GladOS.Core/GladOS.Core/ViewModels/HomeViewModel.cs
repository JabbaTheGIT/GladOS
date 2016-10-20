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
        public ICommand UpdateLocationPressed { get; private set; }

        private void LoggedInUser()
        {
            Name = GlobalLocalPerson.Name;
            Number = GlobalLocalPerson.Number;
            Email = GlobalLocalPerson.Email;
            Employer = GlobalLocalPerson.Employer;
        }

        public HomeViewModel()
        {
            LoggedInUser();

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

            UpdateLocationPressed = new MvxCommand(() =>
            {
                base.ShowViewModel<PublishLocationViewModel>();
            });

        }//End SecondViewModel
    }
}
