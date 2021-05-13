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
            (bool isAuth, string User) = SecurityValidation.IsAuth(OperationContext.Current.ServiceSecurityContext);
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
            (bool isAuth, string User) = SecurityValidation.IsAuth(OperationContext.Current.ServiceSecurityContext);
            var C = A + B; 
            Console.WriteLine("{0} {1} {2} = {3}", A, nameof(Add), B, C); 
            return C; 
        }

        public double multiply(double A, double B)
        {
            (bool isAuth, string User) = SecurityValidation.IsAuth(OperationContext.Current.ServiceSecurityContext);
            var C = A * B;
            Console.WriteLine("{0} {1} {2} = {3}", A, nameof(multiply), B, C);
            return C;
        }

        public double Substract(double A, double B)
        {
            (bool isAuth, string User) = SecurityValidation.IsAuth(OperationContext.Current.ServiceSecurityContext);
            var C = A - B;
            Console.WriteLine("{0} {1} {2} = {3}", A, nameof(Substract), B, C);
            return C;
        }
    }

    class SecurityValidation
    {
        public static (bool isAuth ,string username) IsAuth(ServiceSecurityContext SecurityContext)
        {
            string username = "Anonymous";
            bool isAuth = false;
            if (ServiceSecurityContext.Current != null)
                if (ServiceSecurityContext.Current.PrimaryIdentity.IsAuthenticated)
                {
                    username = SecurityContext.PrimaryIdentity.Name; //  WindowsIdentity.Name; was only suppoted on Windows 
                    isAuth = true;
                }
                else
                    username = "Anonymous";

            Console.WriteLine("User: {0} isAuth: {1}", username, isAuth);
            return (isAuth, username); 
        }
    }
}
