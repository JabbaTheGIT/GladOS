using System;
using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using gladOS.Droid.Models;

namespace gladOS.Droid.Views
{
    [Activity(Label = "EventViewModel")]
    public class EventView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.EventView);
        }

    }
}
