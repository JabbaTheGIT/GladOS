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
            ScanBarcodeViewModel scanVM;

            scanVM = ViewModel as ScanBarcodeViewModel;

            Button updateOffice = FindViewById<Button>(Resource.Id.UpdateOffice);
            Button createOffice = FindViewById<Button>(Resource.Id.CreateOffice);
            EditText officeNumber = FindViewById<EditText>(Resource.Id.OfficeNumber);
            EditText buildingLevel = FindViewById<EditText>(Resource.Id.BuildingLevel);
            EditText buildingAdress = FindViewById<EditText>(Resource.Id.BuildingAdress);
            EditText buildingPostCode = FindViewById<EditText>(Resource.Id.BuildingPostCode);

            /*
            if (scanVM.saveOffice == true)
            {
                updateOffice.Visibility = ViewStates.Visible;
            }
            if(scanVM.saveOffice == false)
            {
                updateOffice.Visibility = ViewStates.Invisible;
            } */
        }

    }
}
