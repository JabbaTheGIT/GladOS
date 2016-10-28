using gladOS.Core.Database;
using gladOS.Core.Interfaces;
using gladOS.Core.Models;
using gladOS.Core.Services;
using MvvmCross.Core.ViewModels;
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
using System.Collections.ObjectModel;
using System.Windows.Input;
using GladOS.Core.Interfaces;
using MvvmCross.Platform;
using GladOS.Core.ViewModels;

/*This view holds the infomation about the local user, view enables them
 *to decide how they would like to be located and save that choice
 */
namespace gladOS.Core.ViewModels
{
    public class ScanBarcodeViewModel : MvxViewModel
    {
        private string barcode;

        public string Barcode
        {
            get { return barcode; }
            set { SetProperty(ref barcode, value); }
        }


        public ICommand GenerateQRCodeCommand { get; private set; }
        public ICommand ScanOnceCommand { get; private set; }
        public IMobileBarcodeScanner scanner;

        public ScanBarcodeViewModel()
        {
            GenerateQRCodeCommand = new MvxCommand<string>(selectedBarcode =>
            {
                ShowViewModel<BarcodeViewModel>(new { param = selectedBarcode });
            });
            ScanOnceCommand = new MvxCommand(ScanOnce);
        }
        public async void ScanOnce()
        {
            var result = await scanner.Scan();
            OnResult(result);
        }

        public void OnResult(ZXing.Result result)
        {
            var barResult = result.Text;
            barcode = barResult;
            Mvx.Resolve<IToast>().Show(string.Format("Bar code = {0} recorded.", barcode));
        }
        public override void Start()
        {
            base.Start();
            var x = Mvx.TryResolve(out scanner);
        }
    }
}
