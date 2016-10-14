using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace GladOS.Droid.Views
{
    [Activity(Label = "MeetingViewModel")]
    public class LoginView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.LoginView);
        }
    }
}