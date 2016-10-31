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

/*This view show all the people in the database, will update to show only searched 
 *for people
 */

namespace gladOS.Core.ViewModels
{
    public class MessagesViewModel : MvxViewModel
    {
        private List<string> messages;
        public List<string> Messages
        {
            get { return messages; }
            set { messages = value; RaisePropertyChanged(() => Messages); }
        }

        public ICommand HomePressed { get; private set; }
        public ICommand SchedulePressed { get; private set; }
        public ICommand SearchPressed { get; private set; }
        public ICommand ProfilePressed { get; private set; }
        public ICommand SelectedMessage { get; private set; }

        public MessagesViewModel()
        {
            Messages = GlobalLocalPerson.messages;

            //Nav buttons
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
                                    
            SelectedMessage = new MvxCommand<PersonInfo>(selectedMessage => 
                             base.ShowViewModel<SelectedIndividualViewModel>(selectedMessage));
      
        }//EndSearchViewModel

    }
}