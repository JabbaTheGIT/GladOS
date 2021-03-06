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

namespace gladOS.Core.Database
{
    public class PersonInfoDatabaseAzure : IPersonInfoDatabase
    {

        private MobileServiceClient azureDatbase;
        private IMobileServiceSyncTable<PersonInfo> azureSyncTable;

        public PersonInfoDatabaseAzure()
        {
            azureDatbase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient();
            azureSyncTable = azureDatbase.GetSyncTable<PersonInfo>();
        }

        public async Task<IEnumerable<PersonInfo>> GetPersons()
        {
            await SyncAsync(true);
            var person = await azureSyncTable.ToListAsync();
            return person;
        }

        public async Task<bool> CheckIfExists(PersonInfo person)
        {
            await SyncAsync(true);
            var persons = await azureSyncTable.Where(x => x.Name == person.Name || x.id == person.id).ToListAsync();
            return persons.Any();
        }



        public async Task<int> DeletePerson(object id)
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

        public async Task<int> UpdatePerson(PersonInfo person)
        {
            await SyncAsync(true);
            await azureSyncTable.UpdateAsync(person);
            await SyncAsync();
            return 1;
        }

        public async Task<int> InsertPerson(PersonInfo person)
        {
            await SyncAsync(true);
            await azureSyncTable.InsertAsync(person);
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
                    await azureSyncTable.PullAsync("allPersons", azureSyncTable.CreateQuery());
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

    }
}
