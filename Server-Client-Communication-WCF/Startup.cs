using CoreWCF;
using CoreWCF.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;


namespace Server_Client_Communication_WCF_Grpc
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServiceModelServices();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            netTcpBinding.TransferMode = TransferMode.Streamed;
            netTcpBinding.Security.Mode = SecurityMode.Transport;
            netTcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows; 


            app.UseServiceModel(builder =>
            {
                builder
                    .AddService<CalculateService>()
                    .AddServiceEndpoint<CalculateService, ClientCommunication.Interfaces.ICalculate>(netTcpBinding, "/nettcp");
            });
        }
    }
}