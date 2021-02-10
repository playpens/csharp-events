using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
  public class EventHub : Hub
  {
    public override async Task OnConnectedAsync()
    {
      Console.WriteLine($"Welcome, {Context.ConnectionId}");
      await base.OnConnectedAsync();
    }

    public async Task Lights(string user, string message)
    {
      Console.WriteLine($"Got Message {message}");
      await Clients.All.SendAsync("TurnLightsOn", user, message);
    }
  }
}
