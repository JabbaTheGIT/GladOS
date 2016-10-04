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

namespace GladOS.Core.ViewModels
{
    public class SecondViewModel : MvxViewModel
    {
        private readonly PersonInfoDatabase personDb;
        private readonly IDialogService dialog;

        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Employer { get; set; }




        public ICommand HomePressed { get; private set; }
        public ICommand SchedulePressed { get; private set; }
        public ICommand SearchPressed { get; private set; }
        public ICommand AddNewPerson { get; private set; }


        public SecondViewModel(IDialogService dialog, PersonInfoDatabase personDb)
        {
            this.personDb = personDb;
            this.dialog = dialog;

            HomePressed = new MvxCommand(() =>
            {
                base.ShowViewModel<SecondViewModel>();
            });

            SchedulePressed = new MvxCommand(() =>
            {
                base.ShowViewModel<FirstViewModel>();
            });

            SearchPressed = new MvxCommand(() =>
            {
                base.ShowViewModel<ThirdViewModel>();
            });

            AddNewPerson = new MvxCommand<Person>(personInfo =>
            {
                SelectedPerson(personInfo);
            });

        }

        public void ClearEntires()
        {
            this.Name = "";
            this.Number = "";
            this.Email = "";
            this.Employer = "";
        }

        public async void SelectedPerson(Person selectedPerson)
        {
            if(!await personDb.CheckIfExists(selectedPerson))
            {
                await personDb.InsertPerson(selectedPerson);
                Close(this);
            }
            else
            {
                if (await dialog.Show("This Person Exists", "Person Exists", "Seach Again", "Return"))
                {
                    ClearEntires();
                }
                else
                {
                    Close(this);
                }
            }
        }
    }
}
