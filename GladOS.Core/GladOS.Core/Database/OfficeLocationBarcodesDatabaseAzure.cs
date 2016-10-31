using gladOS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gladOS.Core.Models;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using MvvmCross.Platform;
using System.Diagnostics;
using GladOS.Core.Models;

namespace gladOS.Core.Database
{
    public class OfficeLocationBarcodesDatabaseAzure : IOfficeLocationBarcodesDatabase
    {

        private MobileServiceClient azureDatbase;
        private IMobileServiceSyncTable<OfficeLocationBarcodes> azureSyncTable;

        public OfficeLocationBarcodesDatabaseAzure()
        {
            azureDatbase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient();
            azureSyncTable = azureDatbase.GetSyncTable<OfficeLocationBarcodes>();
        }

        public async Task<IEnumerable<OfficeLocationBarcodes>> GetOfficeLocation()
        {
            await SyncAsync(true);
            var person = await azureSyncTable.ToListAsync();
            return person;
        }

        public async Task<bool> CheckIfExists(OfficeLocationBarcodes OfficeLocation)
        {
            await SyncAsync(true);
            var persons = await azureSyncTable.Where(x => x.Barcode == OfficeLocation.Barcode || x.id == OfficeLocation.id).ToListAsync();
            return persons.Any();
        }



        public async Task<int> DeleteOfficeLocation(object id)
        {
            await SyncAsync(true);
            var person = await azureSyncTable.Where(x => x.id.ToString() == id.ToString()).ToListAsync();
            if (person.Any())
            {
                await azureSyncTable.DeleteAsync(person.FirstOrDefault());
                await SyncAsync();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> UpdateOfficeLocation(OfficeLocationBarcodes OfficeLocation)
        {
            await SyncAsync(true);
            await azureSyncTable.UpdateAsync(OfficeLocation);
            await SyncAsync();
            return 1;
        }

        public async Task<int> InsertOfficeLocation(OfficeLocationBarcodes OfficeLocation)
        {
            await SyncAsync(true);
            await azureSyncTable.InsertAsync(OfficeLocation);
            await SyncAsync();
            return 1;
        }

        private async Task SyncAsync(bool pullData = false)
        {
            try
            {
                await azureDatbase.SyncContext.PushAsync();

                if(pullData)
                {
                    await azureSyncTable.PullAsync("allOfficeLocationBarcodes", azureSyncTable.CreateQuery());
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

    }
}
