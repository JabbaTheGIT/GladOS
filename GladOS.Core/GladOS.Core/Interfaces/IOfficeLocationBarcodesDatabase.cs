using gladOS.Core.Models;
using GladOS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gladOS.Core.Interfaces
{
    public interface IOfficeLocationBarcodesDatabase
    {
        Task<IEnumerable<OfficeLocationBarcodes>> GetOfficeLocation();
        Task<int> DeleteOfficeLocation(object id);
        Task<int> InsertOfficeLocation(OfficeLocationBarcodes OfficeLocation);
        Task<bool> CheckIfExists(OfficeLocationBarcodes OfficeLocation);
        Task<int> UpdateOfficeLocation(OfficeLocationBarcodes OfficeLocation);

    }
}
