using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace GladOS.Droid.Views
{
    [Activity(Label = "FirstViewModel")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.FirstView);
        }
    }
}
