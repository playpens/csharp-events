using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace Client
{
  class Program
  {

    static void Main(string[] args)
    {
      Start();
    }

    public static async void Start()
    {

      var url = "https://localhost:44371/events";

      HubConnection connection = new HubConnectionBuilder()
        .WithUrl(url)
        .WithAutomaticReconnect()
        .Build();

      // receive a message from the hub
      connection.On<string, string>("message", (user, message) => OnReceiveMessage(user, message));

      var t = connection.StartAsync();

      t.Wait();

      Console.ReadLine();
    }

    private static void OnReceiveMessage(string user, string message)
    {
      Console.WriteLine($"Message Received: {message}");
    }
  }
}
