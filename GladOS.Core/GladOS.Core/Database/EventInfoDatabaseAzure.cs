using GladOS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GladOS.Core.Models;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using MvvmCross.Platform;
using System.Diagnostics;

namespace GladOS.Core.Database
{
    public class EventInfoDatabaseAzure : IEventInfoDatabase
    {

        private MobileServiceClient azureDatbase;
        private IMobileServiceSyncTable<Event> azureSyncTable;

        public EventInfoDatabaseAzure()
        {
            azureDatbase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient();
            azureSyncTable = azureDatbase.GetSyncTable<Event>();
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            await SyncAsync(true);
            var events = await azureSyncTable.ToListAsync();
            return events;
        }

        public async Task<bool> CheckEventExists(Event events)
        {
            await SyncAsync(true);
            var exists = await azureSyncTable.Where(x => x.EventTitle == events.EventTitle).ToListAsync();
            return exists.Any();
        }

        public async Task<int> DeleteEvent(object id)
        {
            await SyncAsync(true);
            var events = await azureSyncTable.Where(x => x.Id.ToString() == id.ToString()).ToListAsync();
            if (events.Any())
            {
                await azureSyncTable.DeleteAsync(events.FirstOrDefault());
                await SyncAsync();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> InsertEvent(Event events)
        {
            await SyncAsync(true);
            await azureSyncTable.InsertAsync(events);
            await SyncAsync();
            return 1;
        }

        private async Task SyncAsync(bool pullData = false)
        {
            try
            {
                await azureDatbase.SyncContext.PushAsync();

                if (pullData)
                {
                    await azureSyncTable.PullAsync("allEvent", azureSyncTable.CreateQuery());
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
