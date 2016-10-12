using MvvmCross.Platform;
using SQLite.Net;
using GladOS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GladOS.Core.Models;

namespace GladOS.Core.Database
{
    public class EventInfoDatabase : IEventInfoDatabase
    {

        private SQLiteConnection database;
        public EventInfoDatabase()
        {
            var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<Event>();
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            var events = database.Table<Event>().ToList();
            return events;
        }

        public async Task<bool> CheckEventExists(Event events)
        {
            var exists = database.Table<Event>()
                .Any(x => x.EventTitle == events.EventTitle);
            return exists;
        }

        public async Task<int> DeleteEvent(object id)
        {
            return database.Delete<Event>(Convert.ToInt16(id));
        }

        public async Task<int> InsertEvent(Event events)
        {
            var num = database.Insert(events);
            database.Commit();
            return num;
        }
    }
}
