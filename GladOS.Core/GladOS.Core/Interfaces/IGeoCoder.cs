using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gladOS.Core.Models;

namespace gladOS.Core.Interfaces {
    public interface IGeoCoder {
        Task<string> GetCityFromLocation(GeoLocation location);
    }
}
