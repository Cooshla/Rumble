using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamnationApp.Core.Interfaces
{
    public interface IRestService
    {
        Task<T> GetClient<T>(string resource, string jsonRequest = "");
        Task<T> PostClient<T>(string resource, string jsonRequest = "");
        Task<T> PutClient<T>(string resource, string jsonRequest = "");

        Task<T> GoogleGetClient<T>(string resource, string jsonRequest = "");
    }
}
