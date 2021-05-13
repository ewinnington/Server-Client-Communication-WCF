using CoreWCF;
using CoreWCF.Configuration;
//using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;

namespace Server_Client_Communication_WCF_Grpc
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();

            services.AddServiceModelServices();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.TransferMode = TransferMode.Streamed;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                binding.Security.Mode = SecurityMode.None;
            }
            else
            {
                binding.Security.Mode = SecurityMode.Transport;
                binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            }

            //app.UseAuthentication();

            app.UseServiceModel(builder =>
            {
                builder
                    .AddService<CalculateService>()
                    .AddServiceEndpoint<CalculateService, ClientCommunication.Interfaces.ICalculate>(binding, "/nettcp");
            });
        }
    }
}