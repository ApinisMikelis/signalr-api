using Microsoft.AspNetCore.SignalR;

namespace SignalRApi;

public sealed class MessageHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} connected.");
    }

    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} : {message}");
    }
}
