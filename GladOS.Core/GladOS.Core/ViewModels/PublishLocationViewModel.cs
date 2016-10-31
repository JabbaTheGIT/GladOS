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

        private Action<GeoLocation, float> moveLocation;

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

        public void updateGlobalLocation(GeoLocation location)
        {
            GlobalLocalPerson.Longitude = location.Longitude;
            GlobalLocalPerson.Latitude = location.Latitude;
        }

        private async void RunSomething()
        {
            while (true)
            {
                await Task.Delay(100);
                //Do a thing
                
            }
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

            UpdateLocation = new MvxCommand(() =>
            {
                UpdatedPersonDb();
                ShowViewModel<HomeViewModel>();
            });
        }//End PublishLocationViewModel

    }
}
