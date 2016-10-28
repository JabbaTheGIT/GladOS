using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace gladOS.Droid.Views
{
    [Activity(Label = "RequestInfomationViewModel")]
    public class RequestInfomationView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.RequestInfomationView);
        }
    }
}
