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
    public class ScheduleViewModel
        : MvxViewModel
    {

        private readonly IPersonInfoDatabase personDb;
        private readonly IEventInfoDatabase eventDb;

        public ICommand HomePressed { get; private set; }
        public ICommand SchedulePressed { get; private set; }
        public ICommand SearchPressed { get; private set; }
        public ICommand ProfilePressed { get; private set; }
        public ICommand EventPressed { get; private set; }
        public ICommand BusyPressed { get; private set; }



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
        
        private List<PersonInfo> persons;
        public List<PersonInfo> Persons
        {
            get { return persons; }
            set { persons = value; RaisePropertyChanged(() => Persons); }
        }

        public async void GetPeople(IPersonInfoDatabase personDb)
        {
            var newList = new List<PersonInfo>();
            PersonProperties personProperties = new PersonProperties();
            var personInfo = await personDb.GetPersons();
            foreach (var person in personInfo)
            {
                PersonInfo newPerson = new PersonInfo();
                newPerson = personProperties.CreatePerson(person.Name, person.Number, person.Employer, person.Email);
                newList.Add(newPerson);
            }

            Persons = newList;
        }

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
            var eventsInfo = await eventDb.GetEvents();
            foreach (var events in eventsInfo)
            {
                Event newEvent = new Event();
                newEvent = eventProperties.CreateEvent(events.EventTitle, events.StartTime, events.EndTime);
                newList.Add(newEvent);
            }

            Events = newList;
        }

        public void ChangeBusyStatus()
        {
            PersonInfo person = new PersonInfo();
            person.id = GlobalLocalPerson.Id;
            person.Name = GlobalLocalPerson.Name;
            person.Number = GlobalLocalPerson.Number;
            person.Email = GlobalLocalPerson.Email;
            person.Employer = GlobalLocalPerson.Employer;
            person.Contactable = GlobalLocalPerson.Contactable;

            if(person.Contactable)
            {
                person.Contactable = false;
                GlobalLocalPerson.Contactable = false;
            }
            else if(!person.Contactable)
            {
                person.Contactable = true;
                GlobalLocalPerson.Contactable = true;
            }

            UpdatedPerson(person);
        }

        public async void UpdatedPerson(PersonInfo updatePerson)
        {
            await personDb.UpdatePerson(updatePerson);
        } //End UpdateddPerson

        public ScheduleViewModel(IPersonInfoDatabase personDb, IEventInfoDatabase eventDb)
        {
            this.personDb = personDb;
            this.eventDb = eventDb;
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

            EventPressed = new MvxCommand(() =>
            {
                ShowViewModel<EventViewModel>();
            });

            BusyPressed = new MvxCommand(() =>
            {
                ChangeBusyStatus();
                Update = GlobalLocalPerson.Contactable.ToString();          
            });

        }
    }
}
