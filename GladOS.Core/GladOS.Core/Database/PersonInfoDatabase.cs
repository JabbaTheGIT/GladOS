using MvvmCross.Platform;
using SQLite.Net;
using gladOS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gladOS.Core.Models;

namespace gladOS.Core.Database
{
    public class PersonInfoDatabase : IPersonInfoDatabase
    {

        private SQLiteConnection database;
        public PersonInfoDatabase()
        {
            var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<PersonInfo>();
        }

        public async Task<IEnumerable<PersonInfo>> GetPersons()
        {
            var persons = database.Table<PersonInfo>().ToList();
            return persons;
        }

        public async Task<int> DeletePerson(object id)
        {
            return database.Delete<PersonInfo>(Convert.ToInt16(id));
        }

        public async Task<int> InsertPerson(PersonInfo person)
        {
            var num = database.Insert(person);
            database.Commit();
            return num;
        }

        public async Task<bool> CheckIfExists(PersonInfo person)
        {
            var exists = database.Table<PersonInfo>()
                .Any(x => x.Name == person.Name || x.Email == person.Email);
            return exists;
        }

        public Task<int> UpdatePerson(PersonInfo person)
        {
            throw new NotImplementedException();
        }
    }
}
