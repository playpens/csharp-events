using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
  public class EventHub : Hub
  {
    public async Task SendMessage(string user, string message)
    {
      Console.WriteLine($"Got Message {message}");
      await Clients.All.SendAsync("message", user, message);
    }
  }
}
