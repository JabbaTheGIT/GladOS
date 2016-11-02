using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using gladOS.Core.Models;
using gladOS.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace gladOS.Droid.Views
{
    [Activity(Label = "ScheduleViewModel")]
    public class ScheduleView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.ScheduleView);

            TextView officeNumber = FindViewById<TextView>(Resource.Id.officeNumber);
            TextView officeLevel = FindViewById<TextView>(Resource.Id.officeLevel);
            TextView officeAddress = FindViewById<TextView>(Resource.Id.officeAddress);
            TextView officePostCode = FindViewById<TextView>(Resource.Id.officePostCode);
            TextView officeNumberTitle = FindViewById<TextView>(Resource.Id.officeNumberTitle);
            TextView officeLevelTitle = FindViewById<TextView>(Resource.Id.officeLevelTitle);
            TextView officeAddressTitle = FindViewById<TextView>(Resource.Id.officeAddressTitle);
            TextView officePostCodeTitle = FindViewById<TextView>(Resource.Id.officePostCodeTitle);

            if (GlobalLocalPerson.OfficeLocation == null)
            {
                officeNumber.Text = "No office selected";
                officeNumber.Visibility = ViewStates.Visible;
                officeLevel.Visibility = ViewStates.Invisible;
                officeAddress.Visibility = ViewStates.Invisible;
                officePostCode.Visibility = ViewStates.Invisible;
                officeNumberTitle.Visibility = ViewStates.Invisible;
                officeLevelTitle.Visibility = ViewStates.Invisible;
                officeAddressTitle.Visibility = ViewStates.Invisible;
                officePostCodeTitle.Visibility = ViewStates.Invisible;
            }
            else
            {
                officeNumber.Text = GlobalLocalPerson.OfficeLocation.OfficeNumber;
                officeLevel.Text = GlobalLocalPerson.OfficeLocation.BuildingLevel;
                officeAddress.Text = GlobalLocalPerson.OfficeLocation.BuildingAddress;
                officePostCode.Text = GlobalLocalPerson.OfficeLocation.BuildingPostCode;
                officeNumber.Visibility = ViewStates.Visible;
                officeLevel.Visibility = ViewStates.Visible;
                officeAddress.Visibility = ViewStates.Visible;
                officePostCode.Visibility = ViewStates.Visible;
                officeNumberTitle.Visibility = ViewStates.Visible;
                officeLevelTitle.Visibility = ViewStates.Visible;
                officeAddressTitle.Visibility = ViewStates.Visible;
                officePostCodeTitle.Visibility = ViewStates.Visible;
            }
        }
    }
}
