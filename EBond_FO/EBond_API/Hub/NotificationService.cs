using EBond_API.Models;
using Microsoft.AspNetCore.SignalR;

namespace EBond_API.Hub
{
    

    public class NotificationService
    {
        private readonly IHubContext<OrderHub> _hub;

        public NotificationService(IHubContext<OrderHub> hub)
        {
            _hub = hub;
        }

        public async Task NotifyOrderUpdate(OrderModels order)
        {
            await _hub.Clients
                .Group(order.custodycd)
                .SendAsync("OrderUpdated", order);
        }
    }
    
}
