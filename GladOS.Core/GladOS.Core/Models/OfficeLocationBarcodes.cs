using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using MvvmCross.Core.ViewModels;

namespace GladOS.Core.Models
{
    public class OfficeLocationBarcodes
    {
        public OfficeLocationBarcodes() { }
        public OfficeLocationBarcodes(OfficeLocationBarcodes officeLocation)
        {
            Barcode = officeLocation.Barcode;
            OfficeNumber = officeLocation.OfficeNumber;
            BuildingLevel = officeLocation.BuildingLevel;
            BuildingAddress = officeLocation.BuildingAddress;
            BuildingPostCode = officeLocation.BuildingPostCode;
        }
        [PrimaryKey, AutoIncrement]
        public string id { get; set; }
        public string Barcode { get; set; }
        public string OfficeNumber { get; set; }
        public string BuildingLevel { get; set; }
        public string BuildingAddress { get; set; }
        public string BuildingPostCode { get; set; }
    }
}
