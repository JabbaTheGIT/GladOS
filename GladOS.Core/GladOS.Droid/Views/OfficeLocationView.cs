using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using gladOS.Core.Models;
using MvvmCross.Droid.Views;

namespace gladOS.Droid.Views
{
    [Activity(Label = "OfficeLocationViewViewModel")]
    public class OfficeLocationView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.OfficeLocationView);
        }
    }
}