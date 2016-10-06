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

namespace GladOS.Core.Database
{
    class PersonInfoDatabaseAzure : IPersonInfoDatabase
    {

        private MobileServiceClient azureDatbase;
        private IMobileServiceSyncTable<Person> azureSyncTable;
        public PersonInfoDatabaseAzure()
        {
            azureDatbase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient();
            azureSyncTable = azureDatbase.GetSyncTable<Person>();
        }

        public async Task<bool> CheckIfExists(Person person)
        {
            var exists = await CheckIfExists(new Person(person));
            return exists;
        }

        public Task<int> DeletePerson(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> GetPersons()
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertPerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
