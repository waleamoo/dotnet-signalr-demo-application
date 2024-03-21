using Microsoft.AspNetCore.SignalR;

namespace SignalRDemoApplication.Hubs
{
    public class ChatHub : Hub
    {
        // a client can contact this method SendMessage remotely 
        public async Task SendMessage(string user, string message) 
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, DateTime.UtcNow.ToShortDateString()); // broadcasting to all clients (RecieveMessage is a remotely client method)
            //await Clients.User("ssssd").SendAsync("ReceiveMessage", user, message); // broadcasting to a client 

        }
    }
}

