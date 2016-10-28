using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using gladOS.Core.Models;
using MvvmCross.Droid.Views;

namespace gladOS.Droid.Views
{
    [Activity(Label = "SelectedIndividualViewModel")]
    public class SelectedIndividualView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.SelectedIndividualView);

            Button viewOnMap = FindViewById<Button>(Resource.Id.SelectedPersonViewMap);
            Button requestInfo = FindViewById<Button>(Resource.Id.RequestInfo);
            TextView infomationToUser = FindViewById<TextView>(Resource.Id.InfoForUser);

            if (GlobalSelectedPerson.Contactable == false)
            {
                //Person not contactable
                viewOnMap.Visibility = ViewStates.Invisible;
                infomationToUser.Text = "The user has set themselves to private, you may send a request but you may not get a reply.";
                requestInfo.Visibility = ViewStates.Visible; 
            }
            if (GlobalSelectedPerson.Contactable == true)
            {
                //Person not contactable
                viewOnMap.Visibility = ViewStates.Visible;
                infomationToUser.Text = "Select View Map for last known location, select Request Info to request up to date location.";
                requestInfo.Visibility = ViewStates.Visible;
            }
        }
    }
}