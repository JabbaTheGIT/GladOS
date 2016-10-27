using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using gladOS.Core.ViewModels;
using gladOS.Core.Models;
using Android.Gms.Common.Apis;
using Android.Gms.Location;
using Android.Gms.Common;

namespace gladOS.Droid.Views
{
    [Activity(Label = "LocationViewModel")]
    public class PublishLocationView : MvxActivity, IOnMapReadyCallback
    {
        private delegate IOnMapReadyCallback OnMapReadyCallback();
        private GoogleMap map;
        PublishLocationViewModel vm;

        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;
            vm.MapSetup(MoveToLocation);
            map.MyLocationEnabled = true;
            map.MyLocationChange += Map_MyLocationChange;
        }

        public void Map_MyLocationChange(object sender, GoogleMap.MyLocationChangeEventArgs e)
        {
            map.MyLocationChange -= Map_MyLocationChange;
            var location = new GeoLocation(e.Location.Latitude, e.Location.Longitude, e.Location.Altitude);
            MoveToLocation(location);
            vm.OnMyLocationChanged(location);
        }


        //Move to current users location, signal from their phone
        private void MoveToLocation(GeoLocation geoLocation, float zoom = 17)
        {
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(new LatLng(geoLocation.Latitude, geoLocation.Longitude));
            builder.Zoom(zoom);
            var cameraPosition = builder.Build();
            var cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
            addPersonPin(geoLocation);
            map.MoveCamera(cameraUpdate);
        }
        //adding pin for local user's mobile
        private void addPersonPin(GeoLocation geoLocation)
        {
            var markerOptions = new MarkerOptions();
            //vm.updateGlobalLocation(geoLocation);
            GlobalLocalPerson.Latitude = geoLocation.Latitude;
            GlobalLocalPerson.Longitude = geoLocation.Longitude;
            markerOptions.SetPosition(new LatLng(geoLocation.Latitude, geoLocation.Longitude));
            markerOptions.SetSnippet(string.Format("{0}, Long: {1}, Lat: {2}", GlobalLocalPerson.Name, 
                                                                               GlobalLocalPerson.Longitude,
                                                                               GlobalLocalPerson.Latitude));
            markerOptions.SetTitle(GlobalLocalPerson.Name);
            map.AddMarker(markerOptions);
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.PublishLocationView);
            vm = ViewModel as PublishLocationViewModel;
            var mapFragment = FragmentManager.FindFragmentById(Resource.Id.publishlocationview)
                              as MapFragment;
            mapFragment.GetMapAsync(this);
        }

    }
}