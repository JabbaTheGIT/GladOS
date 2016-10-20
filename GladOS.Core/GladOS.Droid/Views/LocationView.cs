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
using GladOS.Core.ViewModels;
using GladOS.Core.Models;
using Android.Gms.Common.Apis;
using Android.Gms.Location;
using Android.Gms.Common;

namespace GladOS.Droid.Views
{
    [Activity(Label = "LocationViewModel")]
    public class LocationView : MvxActivity, IOnMapReadyCallback, GoogleApiClient.IConnectionCallbacks, GoogleApiClient.IOnConnectionFailedListener
    {
        private delegate IOnMapReadyCallback OnMapReadyCallback();
        private GoogleMap map;
        LocationViewModel vm;

        public void OnMapReady(GoogleMap googleMap)
        {
            //vm.OnMapSetup(MoveToLocation);
            map = googleMap;
            MoveToSelectedPersonLocation();
            //map.MyLocationEnabled = true;
            //map.MyLocationChange += Map_MyLocationChange;
        }

        public void Map_MyLocationChange(object sender, GoogleMap.MyLocationChangeEventArgs e)
        {
            map.MyLocationChange -= Map_MyLocationChange;
            var location = new GeoLocation(e.Location.Latitude, e.Location.Longitude, e.Location.Altitude);
            MoveToLocation(location);
            vm.OnMyLocationChanged(location);
        }

        public void CallUserMapLocation(GoogleMap goolgeMap)
        {
            vm.OnMapSetup(MoveToLocation);
            map.MyLocationEnabled = true;
            map.MyLocationChange += Map_MyLocationChange;
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
            markerOptions.SetPosition(new LatLng(geoLocation.Latitude, geoLocation.Longitude));
            markerOptions.SetSnippet(vm.personNumber);
            markerOptions.SetTitle(vm.personName);
            map.AddMarker(markerOptions);
        }

        //This function moves the map to the selected persons location
        private void MoveToSelectedPersonLocation(float zoom = 17)
        {
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(new LatLng(vm.persLat, vm.persLong));
            builder.Zoom(zoom);
            var cameraPosition = builder.Build();
            var cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
            addSelectedPersonPin();
            map.MoveCamera(cameraUpdate);
        }
        //Selected persons pin
        private void addSelectedPersonPin()
        {
            var markerOptions = new MarkerOptions();
            markerOptions.SetPosition(new LatLng(vm.persLat, vm.persLong));
            markerOptions.SetSnippet(vm.personNumber);
            markerOptions.SetTitle(vm.personName);
            map.AddMarker(markerOptions);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.LocationView);
            vm = ViewModel as LocationViewModel;
            var mapFragment = FragmentManager.FindFragmentById(Resource.Id.locationview)
                              as MapFragment;
            mapFragment.GetMapAsync(this);
        }

        public void OnConnected(Bundle connectionHint)
        {
            var client = new GoogleApiClient.Builder(this)
                             .AddConnectionCallbacks(this)
                             .AddOnConnectionFailedListener(this)
                             .AddApi(LocationServices.API).Build();
        }

        public void OnConnectionSuspended(int cause)
        {
            throw new NotImplementedException();
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
            throw new NotImplementedException();
        }
    }
}