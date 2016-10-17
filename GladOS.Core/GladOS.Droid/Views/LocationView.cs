using Android.App;
using Android.OS;
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
using MvvmCross.Droid.Views;

namespace GladOS.Droid.Views
{
    [Activity(Label = "LocationViewModel")]
    public class LocationView : MvxActivity, IOnMapReadyCallback
    {
        private delegate IOnMapReadyCallback OnMapReadyCallback();
        private GoogleMap map;
        LocationViewModel vm;

        public void OnMapReady(GoogleMap googleMap)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.LocationView);
            vm = ViewModel as LocationViewModel;
            var mapFragment = FragmentManager.FindFragmentById(Resource.Id.locationmap)
                              as MapFragment;
            mapFragment.GetMapAsync(this);
        }
    }
}