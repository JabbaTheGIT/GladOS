using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladOS.Core.Models
{
    public class OfficeLocalProp
    {

        public OfficeLocationBarcodes CreateBarcode()
        {
            return new OfficeLocationBarcodes()
            {
                Barcode = "",
                OfficeNumber = "",
                BuildingLevel = "",
                BuildingAddress = "",
                BuildingPostCode = ""
            };
        }

        public OfficeLocationBarcodes CreateBarcode(string barcode, string officeNumber, string buildingLevel,
                                                    string buildingAddress, string buildingPostCode)
        {
            return new OfficeLocationBarcodes()
            {
                Barcode = barcode,
                OfficeNumber = officeNumber,
                BuildingLevel = buildingLevel,
                BuildingAddress = buildingAddress,
                BuildingPostCode = buildingPostCode
            };
        }

    }
}
