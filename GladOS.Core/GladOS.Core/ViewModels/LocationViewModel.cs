﻿using gladOS.Core.Models;
using gladOS.Core.Services;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Linq;
using gladOS.Core.Interfaces;
using gladOS.Core.Database;
using System;
using System.Threading.Tasks;

/*This view holds the infomation about the local user, view enables them
 *to decide how they would like to be located and save that choice
 */
namespace gladOS.Core.ViewModels
{
    public class LocationViewModel : MvxViewModel
    {
        public ICommand HomePressed { get; private set; }
        public ICommand SchedulePressed { get; private set; }
        public ICommand SearchPressed { get; private set; }
        public ICommand ProfilePressed { get; private set; }

        private readonly IGeoCoder geocoder;

        public double persLat = GlobalSelectedPerson.Latitude;
        public double persLong = GlobalSelectedPerson.Longitude;
        public string personName = GlobalSelectedPerson.Name;
        public string personNumber = GlobalSelectedPerson.Number;

        private Action<GeoLocation, float> moveToLocation;
        private GeoLocation myLocation;
        public GeoLocation MyLocation
        {
            get { return myLocation; }
            set { myLocation = value; }
        }
        
        public void OnMyLocationChanged(GeoLocation location)
        {
            MyLocation = location;
        }

        private async void RunSomething()
        {
            while (true)
            {
                await Task.Delay(100);
                //Do a thing
            }
        }

        public void OnMapSetup(Action<GeoLocation,float> MoveToLocation)
        {
            moveToLocation = MoveToLocation;
        }

        public LocationViewModel(IGeoCoder geocoder)
        {
            this.geocoder = geocoder;
            RunSomething();
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


        }//End Location ViewModel

    }
}
