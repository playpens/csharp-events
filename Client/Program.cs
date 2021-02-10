//using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

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

      try
      {
        var url = "https://localhost:44371/signalr";

        HubConnection connection = new HubConnectionBuilder()
          .WithUrl(url)
          .WithAutomaticReconnect()
          .Build();

        connection.On<string, string>("TurnLightsOn", (user, message) => OnReceiveMessage(user, message));

        var t = connection.StartAsync();
        t.Wait();

        Console.WriteLine($"Connected ... ID: {connection.ConnectionId}");

        Console.ReadLine();
      }
      catch (Exception e)
      {
        Console.WriteLine("Never Connected");
        Console.WriteLine(e.Message);
      }
    }

    private static void OnReceiveMessage(string user, string message)
    {
      Console.WriteLine($"Message Received: {message}");
    }
  }
}
