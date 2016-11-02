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
using System.Threading.Tasks;


namespace gladOS.Core.ViewModels
{
    public class PublishLocationViewModel : MvxViewModel
    {
        private readonly IGeoCoder geocoder;
        private readonly IPersonInfoDatabase personDb;

        public ICommand UpdateLocation { get; private set; }
        public ICommand HomePressed { get; private set; }
        public ICommand SchedulePressed { get; private set; }
        public ICommand SearchPressed { get; private set; }
        public ICommand ProfilePressed { get; private set; }

        private Action<GeoLocation, float> moveLocation;

        private GeoLocation myLocation;
        public GeoLocation MyLocation
        {
            get { return myLocation; }
            set { myLocation = value; }
        }

        private bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }

            set
            {
                isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public void OnMyLocationChanged(GeoLocation location)
        {
            MyLocation = location;
        }

        public void updateGlobalLocation(GeoLocation location)
        {
            GlobalLocalPerson.Longitude = location.Longitude;
            GlobalLocalPerson.Latitude = location.Latitude;
        }

        public async void UpdatedPersonDb()
        {
            PersonInfo updatePerson = new PersonInfo();
            updatePerson.id = GlobalLocalPerson.Id;
            updatePerson.Name = GlobalLocalPerson.Name;
            updatePerson.Number = GlobalLocalPerson.Number;
            updatePerson.Employer = GlobalLocalPerson.Employer;
            updatePerson.Email = GlobalLocalPerson.Email;
            updatePerson.Contactable = GlobalLocalPerson.Contactable;
            updatePerson.Latitude = GlobalLocalPerson.Latitude;
            updatePerson.Longitude = GlobalLocalPerson.Longitude;
            await personDb.UpdatePerson(updatePerson);
            IsBusy = false;
            ShowViewModel<HomeViewModel>();
        } //End UpdateddPerson

        public void MapSetup(Action<GeoLocation,float> MoveLocation)
        {
            moveLocation = MoveLocation;
        }

        //Start PublishLocationViewModel
        public PublishLocationViewModel(IGeoCoder geocoder, IPersonInfoDatabase personDb)
        {
            this.geocoder = geocoder;
            this.personDb = personDb;

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

            UpdateLocation = new MvxCommand(() =>
            {
                IsBusy = true;
                UpdatedPersonDb();
            });
        }//End PublishLocationViewModel

    }
}
