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
        Task<IEnumerable<PersonInfo>> GetPersons();
        Task<int> DeletePerson(object id);
        Task<int> InsertPerson(PersonInfo person);
        Task<bool> CheckIfExists(PersonInfo person);
        Task<int> UpdatePerson(PersonInfo person);

    }
}
