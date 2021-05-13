using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using ClientCommunication.Interfaces; 

namespace WCF_client_windows
{
    class Program
    {
        static void Main(string[] args)
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.TransferMode = TransferMode.Streamed;
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;

            EndpointAddress endpointAddress = new EndpointAddress(@"net.tcp://localhost:8089/nettcp");
            ICalculate client = ChannelFactory<ICalculate>.CreateChannel(binding, endpointAddress);  //new MyClientImplementation(NetTcp, BaseAddress);

            Console.WriteLine("Invoking CalculatorService at {0}", endpointAddress);

            double value1 = 100.00D;
            double value2 = 15.99D;

            // Call the Add service operation.
            double result = client.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

            // Call the Subtract service operation.
            result = client.Substract(value1, value2);
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

            // Call the Multiply service operation.
            result = client.multiply(value1, value2);
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

            result = client.Action(new Inputs() { A = 100, B = 30, Operation = Inputs.OperationEnum.Multiplication });
            Console.WriteLine("Action with DataModel {0}", result); 

            //Closing the client gracefully closes the connection and cleans up resources
            ((IClientChannel)client).Close();
            Console.WriteLine("Closed Proxy");
        }
    }
}
