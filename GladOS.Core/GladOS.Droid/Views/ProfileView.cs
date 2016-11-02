using Android.App;
using Android.OS;
using gladOS.Core.ViewModels;
using gladOS.Droid.Services;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Views;

namespace gladOS.Droid.Views
{
    [Activity(Label = "ProfileViewModel")]
    public class ProfileView : MvxActivity
    {
        private Progress progress;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.ProfileView);
            progress = new Progress(this);

            var set = this.CreateBindingSet<ProfileView, ProfileViewModel>();
            set.Bind(progress).For(p => p.Visible).To(vm => vm.IsBusy);
            set.Apply();
        }
    }
}