using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Views;
using gladOS.Droid.Services;
using gladOS.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using gladOS.Droid.Constants;

namespace gladOS.Droid.Views
{

    [Activity(Label = "LoginViewModel")]
    public class LoginView : MvxActivity
    {
        private Progress progress;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Window.RequestFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.LoginView);
            progress = new Progress(this);

            var set = this.CreateBindingSet<LoginView, LoginViewModel>();
            set.Bind(progress).For(p => p.Visible).To(vm => vm.IsBusy);
            set.Apply();
            
        }

    }
}
