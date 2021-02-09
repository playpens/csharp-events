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

      var url = "https://localhost:44371/events";

      HubConnection connection = new HubConnectionBuilder()
        .WithUrl(url)
        .WithAutomaticReconnect()
        .Build();

      // send a message to the hub
      await connection.InvokeAsync("SendMessage", "publisher", "Message from the publisher app");
    }

  }
}
