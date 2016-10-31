using gladOS.Core.Interfaces;
using gladOS.Core.Models;
using gladOS.Core.Services;
using GladOS.Core.Models;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;

/*This view carries on from the search view, it displays the selected 
 * person chosen by the user from the search page
 */

namespace gladOS.Core.ViewModels
{
    public class OfficeLocationViewModel : MvxViewModel
    {
        public ICommand CreateOffice { get; private set; }

        IOfficeLocationBarcodesDatabase officeLocations;

        private string userPrompt = "Please ensure all boxes are filled";

        public string UserPrompt
        {
            get { return userPrompt; }
            set
            {
                userPrompt = value;
                RaisePropertyChanged(() => UserPrompt);
            }
        }


        private string barcodeNumber;

        public string BarcodeNumber
        {
            get { return barcodeNumber; }
            set { barcodeNumber = value; }
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

        public async void SyncLocation()
        {
            OfficeLocationBarcodes newOffice = new OfficeLocationBarcodes();
            OfficeLocalProp officeProp = new OfficeLocalProp();
            newOffice = officeProp.CreateBarcode(BarcodeNumber, OfficeNumber, BuildingLevel, BuildingAdress, BuildingPostCode);
            GlobalLocalPerson.OfficeLocation = newOffice;
            await officeLocations.InsertOfficeLocation(newOffice);
        }

        public bool CheckEntries()
        {
            if (BarcodeNumber == null || BarcodeNumber == "") return false;
            if (OfficeNumber == null || OfficeNumber == "") return false;
            if (BuildingLevel == null || BuildingLevel == "") return false;
            if (BuildingAdress == null || BuildingAdress == "") return false;
            if (BuildingPostCode == null || BuildingPostCode == "") return false;
            return true;
        }

        public OfficeLocationViewModel(IOfficeLocationBarcodesDatabase officeLocations)
        {
            this.officeLocations = officeLocations;

            BarcodeNumber = GlobalBarcode.GlobalBarcodes;

            CreateOffice = new MvxCommand(() =>
            {
                bool correctlyFilledOut = CheckEntries();
                if(correctlyFilledOut == false)
                {
                    UserPrompt = "You did not fill all the boxes fully! Please update the boxes.";
                }
                if (correctlyFilledOut == true)
                {
                    SyncLocation();
                    ShowViewModel<ScanBarcodeViewModel>();
                }
            });

        }
    }
}