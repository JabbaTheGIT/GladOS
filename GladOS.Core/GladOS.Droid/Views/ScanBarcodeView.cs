using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ZXing.Mobile;
using MvvmCross.Droid.Views;
using gladOS.Droid.Models;
using gladOS.Core.ViewModels;
using gladOS.Droid.Services;
using MvvmCross.Binding.BindingContext;

namespace gladOS.Droid.Views
{
    [Activity(Label = "ScanBarcodeViewModel")]
    public class ScanBarcodeView : MvxActivity
    {
        private Progress progress;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.ScanBarcodeView);
            MobileBarcodeScanner.Initialize(this.Application);
            progress = new Progress(this);

            var set = this.CreateBindingSet<ScanBarcodeView, ScanBarcodeViewModel>();
            set.Bind(progress).For(p => p.Visible).To(vm => vm.IsBusy);
            set.Apply();
        }
    }
}
