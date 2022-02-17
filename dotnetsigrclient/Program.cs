using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dotnetsigrclient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Preparing the connection..");
            
            // setting up the proxy hub
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("https://api.skchase.com/checkout")
                .Build();

            // start connection
            await connection.StartAsync();
            Console.WriteLine("Connected");

            // get vouchers from skchase for a sample SalesChannelID
            Object str = await connection.InvokeAsync<Object>("GetVouchers", "680cbfbc-76a6-cb30-4c04-39b26251f870");
            
            // print vouchers to console
            Console.WriteLine("Check this out : " + str);

            // keep the console alive to view result
            Console.ReadKey();
        }

    }
}
