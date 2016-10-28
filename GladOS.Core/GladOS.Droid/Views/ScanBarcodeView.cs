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

namespace gladOS.Droid.Views
{
    [Activity(Label = "ScanBarcodeViewModel")]
    public class ScanBarcodeView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.ScanBarcodeView);
            MobileBarcodeScanner.Initialize(this.Application);
        }

    }
}
