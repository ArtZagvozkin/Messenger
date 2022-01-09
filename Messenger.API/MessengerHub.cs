using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Messenger.API
{
    public class MessengerHub : Hub
    {
        public async Task Send(string message_hub)
        {
            await this.Clients.All.SendAsync("Send", message_hub);
        }
    }
}
