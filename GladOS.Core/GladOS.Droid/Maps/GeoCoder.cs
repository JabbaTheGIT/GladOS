
using Android.App;
using Android.Locations;
using GladOS.Core.Interfaces;
using GladOS.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace GladOS.Droid.Maps
{
    public class GeoCoder: IGeoCoder
    {
        public async Task<string> GetCityFromLocation(GeoLocation location)
        {
            var geocoder = new Geocoder(Application.Context);
            var foundLocation = await geocoder.GetFromLocationAsync(location.Latitude, location.Longitude, 1);
            return foundLocation.FirstOrDefault().Locality;
        }

    }
}