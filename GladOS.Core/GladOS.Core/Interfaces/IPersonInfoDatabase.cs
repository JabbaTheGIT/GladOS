using gladOS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gladOS.Core.Interfaces
{
    public interface IPersonInfoDatabase
    {
        Task<IEnumerable<Person>> GetPersons();
        Task<int> DeletePerson(object id);
        Task<int> InsertPerson(Person person);
        Task<bool> CheckIfExists(Person person);
        Task<int> UpdatePerson(Person person);

    }
}
