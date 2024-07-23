using Microsoft.AspNetCore.SignalR;

namespace SignalR_Api.Hubs
{
    public class MyHub : Hub
    {
        public async Task SendMessage(string FromToConnectionId, string message, string? SendToconnectionId = null)
        {
            if (string.IsNullOrEmpty(SendToconnectionId))
            {

                await Clients.All.SendAsync("receiveMessage", FromToConnectionId, message);
            }
            else
            {
                string logMessage = await Clients.Client(SendToconnectionId).InvokeAsync<string>("receiveMessage", FromToConnectionId, message, SendToconnectionId, new());

                Console.WriteLine(logMessage);

            }

        }
    }
}
