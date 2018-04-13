using JamnationApp.Core.Interfaces;
using JamnationApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamnationApp.Core.Services
{
    public class LocationServices : ILocationServices
    {
        private IRestService Rest { get; set; }

        public LocationServices(IRestService _rest)
        {
            Rest = _rest; 
        }

        //https://maps.googleapis.com/maps/api/place/autocomplete/json?input=
        public async Task<GoogleAddresses> GetAddressesAsync(string search)
        {
            var d = await Rest.GoogleGetClient<GoogleAddresses>("place/autocomplete/json?input=" + search + "&components=country:GB");
            return d;
        }
    }

}
