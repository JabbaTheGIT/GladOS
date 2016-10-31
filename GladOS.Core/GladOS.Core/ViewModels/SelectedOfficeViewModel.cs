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
    public class SelectedOfficeViewModel : MvxViewModel
    {
        private OfficeLocationBarcodes selectedOffice;
        public ICommand SaveOffice { get; private set; }
        public ICommand GoBack { get; private set; }
        IPersonInfoDatabase personDb;

        private string barcode;

        public string Barcode
        {
            get { return barcode; }
            set { SetProperty(ref barcode, value); }
        }

        private string officeNumber;

        public string OfficeNumber
        {
            get { return officeNumber; }
            set { SetProperty(ref officeNumber, value); }
        }

        private string buildingLevel;

        public string BuildingLevel
        {
            get { return buildingLevel; }
            set { SetProperty(ref buildingLevel, value); }
        }

        private string buildingAddress;

        public string BuildingAddress
        {
            get { return buildingAddress; }
            set { SetProperty(ref buildingAddress, value); }
        }

        private string buildingPostCode;

        public string BuildingPostCode
        {
            get { return buildingPostCode; }
            set { SetProperty(ref buildingPostCode, value); ; }
        }

        public void SyncGlobalPerson()
        {
            GlobalLocalPerson.OfficeLocation = selectedOffice;
        }

        public void InitialiseVars()
        {
            Barcode = selectedOffice.Barcode;
            BuildingAddress = selectedOffice.BuildingAddress;
            BuildingLevel = selectedOffice.BuildingLevel;
            BuildingPostCode = selectedOffice.BuildingPostCode;
            OfficeNumber = selectedOffice.OfficeNumber;
        }

        public void Init(OfficeLocationBarcodes parameters)
        {
            selectedOffice = parameters;
        }
        public override void Start()
        {
            base.Start();
            InitialiseVars();
        }

        public async void SyncWithPersonDb()
        {

            PersonInfo updateMe = new Models.PersonInfo();
            PersonProperties persProp = new PersonProperties();
            updateMe = persProp.CreatePerson(GlobalLocalPerson.Id, GlobalLocalPerson.Name, GlobalLocalPerson.Number, GlobalLocalPerson.Employer, GlobalLocalPerson.Email
                                              , GlobalLocalPerson.Latitude, GlobalLocalPerson.Longitude, GlobalLocalPerson.Contactable);
            updateMe.OfficeLocation = "Office: " + GlobalLocalPerson.OfficeLocation.OfficeNumber + ", Level: " + GlobalLocalPerson.OfficeLocation.BuildingLevel + ", " +
                                      GlobalLocalPerson.OfficeLocation.BuildingAddress + ", Post Code: " + GlobalLocalPerson.OfficeLocation.BuildingPostCode;
            await personDb.UpdatePerson(updateMe);
        }

        public SelectedOfficeViewModel(IPersonInfoDatabase personDb)
        {
            this.personDb = personDb;

            SaveOffice = new MvxCommand(() =>
            {
                SyncGlobalPerson();
                SyncWithPersonDb();
                ShowViewModel<ScanBarcodeViewModel>();
            });

            GoBack = new MvxCommand(() =>
            {
                ShowViewModel<ScanBarcodeViewModel>();
            });
        }
    }
}