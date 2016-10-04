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
    public class PersonInfoDatabase
    {

        private SQLiteConnection database;
        public PersonInfoDatabase()
        {
            var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<Person>();
        }

        public async Task<IEnumerable<Person>> GetPersons()
        {
            return database.Table<Person>().ToList();
        }

        public async Task<int> DeletePerson(object id)
        {
            return database.Delete<Person>(Convert.ToInt16(id));
        }

        public async Task<int> InsertPerson(Person person)
        {
            var num = database.Insert(person);
            database.Commit();
            return num;
        }

        public async Task<bool> CheckIfExists(Person person)
        {
            var exists = database.Table<Person>()
                .Any(x => x.Name == person.Name || x.Email == person.Email);
            return exists;
        }


    }
}
