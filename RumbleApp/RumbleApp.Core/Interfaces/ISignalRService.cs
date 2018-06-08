using JamnationApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JamnationApp.Core.Models.Events;

namespace JamnationApp.Core.Interfaces
{
    public interface ISignalRService
    {
        event MessageReceived OnMessageReceived;
        void SendMessage(string username, string text);

        Task Start();

        bool IsConnectedOrConnecting();
    }
}
