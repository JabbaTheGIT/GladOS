//William Gwilt n9425438
//NSC Industries prject GladOS

using Android;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.OS;

/*This view enable the user to log meeting times into their 
 *local calendar or set quite/do not disturb times
 */

namespace GladOS.Core.ViewModels
{
    public class ScheduleViewModel
        : MvxViewModel
    {
        private string update = "";

        public string Update
        {
            get { return update; }

            set
            {
                update = value;
                RaisePropertyChanged(() => Update);
            }
        }

        public ICommand HomePressed { get; private set; }
        public ICommand SchedulePressed { get; private set; }
        public ICommand SearchPressed { get; private set; }
        public ICommand ProfilePressed { get; private set; }
        public ICommand InAMeetingPressed { get; private set; }
        public ICommand OfficeHoursPressed { get; private set; }
        public ICommand BusyPressed { get; private set; }
        public ICommand FreeTimePressed { get; private set; }
        public ICommand Calendar { get; private set; }

        public ScheduleViewModel()
        {
            HomePressed = new MvxCommand(() =>
            {
                base.ShowViewModel<HomeViewModel>();
            });

            SchedulePressed = new MvxCommand(() =>
            {
                base.ShowViewModel<ScheduleViewModel>();
            });

            SearchPressed = new MvxCommand(() =>
            {
                base.ShowViewModel<SearchViewModel>();
            });

            ProfilePressed = new MvxCommand(() =>
            {
                Update = "Profile Pressed";
            });

            InAMeetingPressed = new MvxCommand(() =>
            {
                base.ShowViewModel<MeetingViewModel>();
            });

            OfficeHoursPressed = new MvxCommand(() =>
            {
                base.ShowViewModel<OfficeViewModel>();
            });

            BusyPressed = new MvxCommand(() =>
            {
                Update = "Busy / Private Time";
            });

            FreeTimePressed = new MvxCommand(() =>
            {
                Update = "Free for meetings or meetup time";
            });

            Calendar = new MvxCommand(() =>
            {
                Update = "Update Calendar and schedule";
            });
        }
    }
}
