using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace gladOS.Droid.Views
{
    [Activity(Label = "SearchViewModel")]
    public class MessagesView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.MessagesView);
        }
    }
}