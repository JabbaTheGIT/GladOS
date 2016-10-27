using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using gladOS.Droid.Services;
using gladOS.Core.ViewModels;
using MvvmCross.Binding.BindingContext;

namespace gladOS.Droid.Views
{
    [Activity(Label = "CreatePersonViewModel")]
    public class CreatePersonView : MvxActivity
    {
        private Progress progress;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.CreatePersonView);
            progress = new Progress(this);

            var set = this.CreateBindingSet<CreatePersonView, CreatePersonViewModel>();
            set.Bind(progress).For(p => p.Visible).To(vm => vm.IsBusy);
            set.Apply();
        }
    }
}