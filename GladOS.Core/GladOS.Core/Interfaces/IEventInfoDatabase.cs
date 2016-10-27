using gladOS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gladOS.Core.Interfaces
{
    public interface IEventInfoDatabase
    {
        Task<IEnumerable<Event>> GetEvents();
        Task<int> DeleteEvent(object id);
        Task<int> InsertEvent(Event events);
        Task<bool> CheckEventExists(Event events);

    }
}
