using gladOS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace gladOS.Core.Interfaces
{
    public interface INotify
    {
        Task<int> PostUpstreamMessages(UpstreamMessages item);
    }
}
