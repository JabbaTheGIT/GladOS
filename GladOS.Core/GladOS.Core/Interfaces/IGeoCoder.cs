using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GladOS.Core.Models;

namespace GladOS.Core.Interfaces {
    public interface IGeoCoder {
        Task<string> GetCityFromLocation(GeoLocation location);
    }
}
