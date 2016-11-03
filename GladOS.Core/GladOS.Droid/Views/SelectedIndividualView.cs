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
            ImageView personPicture = FindViewById<ImageView>(Resource.Id.selectedPicture);

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

            string name = GlobalSelectedPerson.Name;

            switch (name)
            {
                case "Bruce Wayne":
                    personPicture.SetImageResource(Resource.Drawable.brucewayne);
                    break;
                case "John Wayne":
                    personPicture.SetImageResource(Resource.Drawable.johnwayne);
                    break;
                case "Gandalf Grey":
                    personPicture.SetImageResource(Resource.Drawable.gandalf);
                    break;
                case "Winston Churchill":
                    personPicture.SetImageResource(Resource.Drawable.winston);
                    break;
                case "Peter Parker":
                    personPicture.SetImageResource(Resource.Drawable.spiderman);
                    break;
                case "Tony Stark":
                    personPicture.SetImageResource(Resource.Drawable.ironMan);
                    break;
                default:
                    personPicture.SetImageResource(Resource.Drawable.steve);
                    break;
            }
        }
    }
}