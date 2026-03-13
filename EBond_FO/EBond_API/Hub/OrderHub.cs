namespace EBond_API.Hub
{
    using EBond_API.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.EntityFrameworkCore;

    [Authorize]
    public class OrderHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            //Context.ConnectionId
            //Context.User
            //Context.UserIdentifier
            //Context.GetHttpContext()
            var user = Context.User;
            Console.WriteLine("Client connected: " + Context.ConnectionId);
            string username = "";
            if (user != null) username = Context.User.FindFirst("username")?.Value ?? "";
            await Groups.AddToGroupAsync(Context.ConnectionId, username);
            await base.OnConnectedAsync();
        }
        
    }
}
