using GladOS.Core.Database;
using GladOS.Core.Interfaces;
using GladOS.Core.Models;
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
    public class ProfileViewModel : MvxViewModel
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
        public ICommand AddNewPerson { get; private set; }

        public void ClearEntires()
        {
            this.Name = "";
            this.Number = "";
            this.Email = "";
            this.Employer = "";
        } //End ClearEntries

        public async void SelectedPerson(Person selectedPerson)
        {
            if (!await personDb.CheckIfExists(selectedPerson))
            {
                await personDb.InsertPerson(selectedPerson);
                Close(this);
            }
            else
            {
                if (await dialog.Show("This Person Exists", "Person Exists", "Add New", "Return"))
                {
                    ClearEntires();
                }
                else
                {
                    Close(this);
                }
            }
        } //End SelectedPerson

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

            AddNewPerson = new MvxCommand(() =>
            {
                Person personInfo = new Person();
                personInfo.Name = Name;
                personInfo.Number = Number;
                personInfo.Email = Email;
                personInfo.Employer = Employer;
                SelectedPerson(personInfo);
            });

        }//End ProfileViewModel

    }
}
