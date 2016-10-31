using RumbleApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumbleApp.Core.Interfaces
{
    public interface ILocationServices
    {
        Task<GoogleAddresses> GetAddressesAsync(string search);
    }
}
