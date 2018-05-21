using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WebLogger.Hubs
{
    public class WebLogHub : Hub
    {
        public Task Subscribe(string groupName)
        {
            if (string.IsNullOrEmpty(groupName))
                throw new ArgumentNullException(string.Format("{0} can not be a null or empty", nameof(groupName)));

            return Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public Task Unsubscribe(string groupName)
        {
            if (string.IsNullOrEmpty(groupName))
                throw new ArgumentNullException(string.Format("{0} can not be a null or empty", nameof(groupName)));

            return Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}