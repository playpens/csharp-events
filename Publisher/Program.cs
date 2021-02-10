using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace Publisher
{
  class Program
  {

    static void Main(string[] args)
    {
      Start();
    }

    public static async void Start()
    {

      var url = "https://localhost:44371/signalr";

      HubConnection connection = new HubConnectionBuilder()
        .WithUrl(url)
        .WithAutomaticReconnect()
        .Build();

      var t = connection.StartAsync();
      t.Wait();

      // send a message to the hub
      await connection.InvokeAsync("Lights", "publisher", "Message from the publisher app");
    }

  }
}
