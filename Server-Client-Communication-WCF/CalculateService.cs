using ClientCommunication.Interfaces;
using CoreWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Client_Communication_WCF_Grpc
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    class CalculateService : ICalculate
    {
        public double Action(Inputs A)
        {
            switch (A.Operation)
            {
                case Inputs.OperationEnum.Addition:
                    return Add(A.A, A.B); 
                case Inputs.OperationEnum.Substraction:
                    return Substract(A.A, A.B); 
                case Inputs.OperationEnum.Multiplication:
                    return multiply(A.A, A.B); 
                default:
                    throw new NotImplementedException();
            }
        }

        public double Add(double A, double B)
        {
            var C = A + B; 
            Console.WriteLine("{0} {1} {2} = {3}", A, nameof(Add), B, C); 
            return C; 
        }

        public double multiply(double A, double B)
        {
            var C = A * B;
            Console.WriteLine("{0} {1} {2} = {3}", A, nameof(multiply), B, C);
            return C;
        }

        public double Substract(double A, double B)
        {
            var C = A - B;
            Console.WriteLine("{0} {1} {2} = {3}", A, nameof(Substract), B, C);
            return C;
        }
    }
}
