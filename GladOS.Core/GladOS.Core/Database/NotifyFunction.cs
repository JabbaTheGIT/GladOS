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

namespace GladOS.Core.Database
{
    public class NotifyFunction : INotify
    {

        private MobileServiceClient azureNotify;
        private IMobileServiceSyncTable<Notify> azureNotifySync;

        public NotifyFunction()
        {
            azureNotify = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient();
            azureNotifySync = azureNotify.GetSyncTable<Notify>();
        }

        public async Task<int> PostNotification(Notify item)
        {
            await SyncAsync(true);
            await azureNotifySync.InsertAsync(item);
            await SyncAsync();
            return 1;
        }

        private async Task SyncAsync(bool pullData = false)
        {
            try
            {
                await azureNotify.SyncContext.PushAsync();

                if (pullData)
                {
                    await azureNotifySync.PullAsync("notify", azureNotifySync.CreateQuery());
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
