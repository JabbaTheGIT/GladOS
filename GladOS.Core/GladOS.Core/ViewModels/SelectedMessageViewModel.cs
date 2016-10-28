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
    public class SelectedMessageViewModel : MvxViewModel
    {
        private string selectedMessage;
        public ICommand ViewMap { get; private set; }
        public ICommand RequestInfo { get; private set; }

        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }


        public void Init(string parameters)
        {
            selectedMessage = parameters;
        }
        public override void Start()
        {
            base.Start();
            Name = "Test";
            Message = selectedMessage;
        }
    }
}