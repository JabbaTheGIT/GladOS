using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using GladOS.Core.Interfaces;
using System.IO;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using GladOS.Core.Models;

namespace GladOS.Droid.Database
{
    public class AzureDatabase : IAzureDatabase
    {
        MobileServiceClient azureDatabase;
        public MobileServiceClient GetMobileServiceClient()
        {
            CurrentPlatform.Init();

            azureDatabase = new MobileServiceClient("https://opglados.azurewebsites.net/");
            InitializedLocal();
            return azureDatabase;
        }

        private void InitializedLocal()
        {
            var sqliteFilename = "PersonSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
            var store = new MobileServiceSQLiteStore(path);
            store.DefineTable<Person>();
            store.DefineTable<Event>();
            azureDatabase.SyncContext.InitializeAsync(store);
        }
    }
}