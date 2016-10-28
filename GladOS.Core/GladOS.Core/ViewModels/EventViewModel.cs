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
using GladOS.Core.Interfaces;
using gladOS.Core.Models;
using System.Collections.Generic;
using gladOS.Core.Services;
using System.Linq;
using gladOS.Core.Interfaces;
using GladOS.Core.ViewModels;

namespace gladOS.Core.ViewModels
{
    public class EventViewModel 
        : MvxViewModel
    {
        private readonly IPersonInfoDatabase persDb;
        private readonly IEventInfoDatabase eventDb;
        private readonly IDialogService dialog;

        public string EventTitle { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public ICommand HomePressed { get; private set; }
        public ICommand SchedulePressed { get; private set; }
        public ICommand SearchPressed { get; private set; }
        public ICommand ProfilePressed { get; private set; }
        public ICommand AddNewEvent { get; private set; }


        private List<Event> events;
        public List<Event> Events
        {
            get { return events; }
            set { events = value; RaisePropertyChanged(() => Events); }
        }

        public async void GetEvents(IEventInfoDatabase eventDb)
        {
            var newList = new List<Event>();
            EventProperties eventProperties = new EventProperties();
            var eventInfo = await eventDb.GetEvents();
            foreach (var events in eventInfo)
            {
                Event newEvent = new Event();
                newEvent = eventProperties.CreateEvent(events.EventTitle, events.StartTime, events.EndTime);
                newList.Add(newEvent);
            }

            Events = newList;
        }

        public async void UpdateEvent(Event events)
        {
            if (!await eventDb.CheckEventExists(events))
            {
                await eventDb.InsertEvent(events);
                Close(this);
            }
            else
            {
                if (await dialog.Show("This Event Exists", "Event Exists", "Add New", "Return"))
                {
                    ClearEntires();
                }
                else
                {
                    Close(this);
                }
            }
        } //End UpdateEvent

        public void ClearEntires()
        {
            this.EventTitle = "";
            this.StartTime = "";
            this.EndTime = "";
        } //End ClearEntries

        public EventViewModel(IDialogService dialog, IPersonInfoDatabase persDb, IEventInfoDatabase eventDb)
        {

            this.eventDb = eventDb;
            this.dialog = dialog;
            GetEvents(eventDb);

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

            AddNewEvent = new MvxCommand(() =>
            {
                /*
                Event newEvent = new Event();
                newEvent.EventTitle = EventTitle;
                newEvent.StartTime = StartTime;
                newEvent.EndTime = EndTime;
                UpdateEvent(newEvent);
                */
                ShowViewModel<ScanBarcodeViewModel>();
            });

        }

    }
}
