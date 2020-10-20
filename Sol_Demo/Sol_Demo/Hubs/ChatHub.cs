using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Hubs
{
    public interface IChatClient
    {
        Task SendMessageToGroupJsMethod(string user, string message);
    }

    public class ChatHub : Hub<IChatClient>
    {
        public async Task JoinGroup(string group)
        {
            await base.Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task SendMessage(string group, string user, string message)
        {
            //await base.Clients.All.SendAsync("SendMessageToClientJsMethod", user, message);
            await base.Clients.Groups(group).SendMessageToGroupJsMethod(user, message);
        }
    }
}