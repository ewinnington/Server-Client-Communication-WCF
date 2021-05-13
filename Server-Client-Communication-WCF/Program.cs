using ClientCommunication.Interfaces;
using CoreWCF;
using CoreWCF.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.ServiceModel;

namespace Server_Client_Communication_WCF_Grpc
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel(options =>
            { })
            .UseNetTcp(8089)
            .UseStartup<Startup>();
    }
}