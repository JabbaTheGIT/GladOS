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
using gladOS.Core.Interfaces;
using gladOS.Core.Models;
using System.Collections.Generic;
using gladOS.Core.Services;
using System.Linq;

/*This view enable the user to log meeting times into their 
 *local calendar or set quite/do not disturb times
 */

namespace gladOS.Core.ViewModels
{
    public class RequestInfomationViewModel
        : MvxViewModel
    {
        private readonly INotify notify;

        public ICommand HomePressed { get; private set; }
        public ICommand SchedulePressed { get; private set; }
        public ICommand SearchPressed { get; private set; }
        public ICommand ProfilePressed { get; private set; }
        public ICommand RequestMapLocation { get; private set; }
        public ICommand RequestOfficeAddress { get; private set; }


        public RequestInfomationViewModel(INotify notify)
        {
            this.notify = notify;


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
                base.ShowViewModel<ProfileViewModel>();
            });

            RequestMapLocation = new MvxCommand(() =>
            {
                UpstreamMessages notifyUs = new UpstreamMessages();
                notifyUs.Message = GlobalSelectedPerson.Name + ". " + GlobalLocalPerson.Name + " would like your map location";
                notify.PostUpstreamMessages(notifyUs);
            });

            RequestOfficeAddress = new MvxCommand(() =>
            {
                UpstreamMessages notifyUs = new UpstreamMessages();
                notifyUs.Message = GlobalSelectedPerson.Name + ". " + GlobalLocalPerson.Name + " would like your office location";
                notify.PostUpstreamMessages(notifyUs);
            });
        }
    }
}
