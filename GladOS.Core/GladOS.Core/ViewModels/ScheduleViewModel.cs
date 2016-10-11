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
using GladOS.Core.Interfaces;
using GladOS.Core.Models;
using System.Collections.Generic;
using GladOS.Core.Services;
using System.Linq;

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

        private List<Person> persons;
        public List<Person> Persons
        {
            get { return persons; }
            set { persons = value; RaisePropertyChanged(() => Persons); }
        }

        public async void GetPeople(IPersonInfoDatabase personDb)
        {
            var newList = new List<Person>();
            PersonProperties personProperties = new PersonProperties();
            var personInfo = await personDb.GetPersons();
            foreach (var person in personInfo)
            {
                Person newPerson = new Person();
                newPerson = personProperties.CreatePerson(person.Name, person.Number, person.Employer, person.Email);
                newList.Add(newPerson);
            }

            Persons = newList;
        }

        public void ChangeBusyStatus(List<Person> persons)
        {
            Person person = new Person();
            if (persons.Count() != 0)
            {
                person = persons.FirstOrDefault();
                if(person.Contactable)
                {
                    person.Contactable = false;
                }
                else if(!person.Contactable)
                {
                    person.Contactable = true;
                }
            }
        }

        private readonly IPersonInfoDatabase personDb;

        public ICommand HomePressed { get; private set; }
        public ICommand SchedulePressed { get; private set; }
        public ICommand SearchPressed { get; private set; }
        public ICommand ProfilePressed { get; private set; }
        public ICommand InAMeetingPressed { get; private set; }
        public ICommand OfficeHoursPressed { get; private set; }
        public ICommand BusyPressed { get; private set; }
        public ICommand FreeTimePressed { get; private set; }
        public ICommand Calendar { get; private set; }



        public ScheduleViewModel(IPersonInfoDatabase personDb)
        {
            this.personDb = personDb;
            GetPeople(personDb);

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
                ChangeBusyStatus(persons);
                Update = persons.FirstOrDefault().Contactable.ToString();
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
