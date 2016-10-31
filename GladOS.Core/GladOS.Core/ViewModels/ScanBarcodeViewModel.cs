﻿using gladOS.Core.Database;
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
using GladOS.Core.Models;

/*This view holds the infomation about the local user, view enables them
 *to decide how they would like to be located and save that choice
 */
namespace gladOS.Core.ViewModels
{
    public class ScanBarcodeViewModel : MvxViewModel
    {
        public bool officeExists = false;
        public bool saveOffice = false;
        public bool createOffice = false;

        private List<OfficeLocationBarcodes> barcode;

        public List<OfficeLocationBarcodes> Barcode
        {
            get { return barcode; }
            set { barcode = value; RaisePropertyChanged(() => Barcode); }
        }

        public OfficeLocationBarcodes newBarcode;

        private string barcodeNumber;

        public string BarcodeNumber
        {
            get { return barcodeNumber; }
            set { barcodeNumber = value; }
        }

        private string location;

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        private string officeNumber;

        public string OfficeNumber
        {
            get { return officeNumber; }
            set { officeNumber = value; }
        }

        private string buildingLevel;

        public string BuildingLevel
        {
            get { return buildingLevel; }
            set { buildingLevel = value; }
        }

        private string buildingAddress;

        public string BuildingAdress
        {
            get { return buildingAddress; }
            set { buildingAddress = value; }
        }

        private string buildingPostCode;

        public string BuildingPostCode
        {
            get { return buildingPostCode; }
            set { buildingPostCode = value; }
        }



        public ICommand GenerateQRCodeCommand { get; private set; }
        public ICommand ScanOnceCommand { get; private set; }
        public ICommand SaveNewBarcode { get; private set; }
        public IMobileBarcodeScanner scanner;
        IOfficeLocationBarcodesDatabase officeLocations;

        public async void GetAllBarcodeLocations(IOfficeLocationBarcodesDatabase officeLocations)
        {
            var newList = new List<OfficeLocationBarcodes>();
            OfficeLocalProp localProps = new OfficeLocalProp();
            var locations = await officeLocations.GetOfficeLocation();
            if(locations.Count() > 0)
            {
                foreach(var location in locations)
                {
                    OfficeLocationBarcodes newLocation = new OfficeLocationBarcodes();
                    newLocation = localProps.CreateBarcode(location.Barcode, location.OfficeNumber, location.BuildingLevel,
                                                           location.BuildingAddress, location.BuildingPostCode);

                    newList.Add(newLocation);
                }
                Barcode = newList;
            }
        }

        public ScanBarcodeViewModel(IOfficeLocationBarcodesDatabase officeLocations)
        {
            this.officeLocations = officeLocations;

            GetAllBarcodeLocations(officeLocations);

            GenerateQRCodeCommand = new MvxCommand<OfficeLocationBarcodes>(selectedOffice =>
                                    base.ShowViewModel<SelectedOfficeViewModel>(selectedOffice));

            /*GenerateQRCodeCommand = new MvxCommand<string>(selectedBarcode =>
            {
                ShowViewModel<SelectedOfficeViewModel>(new { param = selectedBarcode });
            });  */

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
            BarcodeNumber = barResult;
            if(Barcode.Count() > 0)
            {
                foreach (var barc in Barcode)
                {
                    if(barc.Barcode == BarcodeNumber)
                    {
                        officeExists = true;
                        Mvx.Resolve<IToast>().Show(string.Format("This office is {0}.", barc.OfficeNumber));
                        saveOffice = true;
                    }
                }
            }
            if(officeExists == false)
            {
                Mvx.Resolve<IToast>().Show(string.Format("Bar code = {0}", barcode));
                createOffice = true;
            }
        }
        public override void Start()
        {
            base.Start();
            var x = Mvx.TryResolve(out scanner);
        }
    }
}
