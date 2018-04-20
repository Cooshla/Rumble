using JamnationApp.Core.Helpers;
using System;
using System.Threading.Tasks;

namespace JamnationApp.Core.Interfaces
{

    public interface ITwilioMessenger
    {
        Task<bool> InitializeAsync();

        void SendMessage(string text);

        Action<Message> MessageAdded { get; set; }
    }
}
