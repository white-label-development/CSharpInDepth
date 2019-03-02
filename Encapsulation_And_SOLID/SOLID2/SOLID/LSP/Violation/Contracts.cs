using System;

namespace SOLID.LSP.Violation
{   
    public interface IBankTerminal1IPaymentGateway
    {
        uint ProcessPayment(decimal amount);
    }
    public interface IBankTerminal2IPaymentGateway
    {
        int ProcessPayment(decimal amount, string uniqueId);
    }

    public interface IBankTerminal
    {
        int ProcessPayment(decimal amount, string uniqueId);
    }
    

    public class BankTerminal1 : IBankTerminal
    {
        private IBankTerminal1IPaymentGateway _gateway;
                
        /// <returns>Response Code. Always >= 0</returns>
        public int ProcessPayment(decimal amount, string uniqueId)
        {
            //doesn't require uniqueId at all
            return (int)_gateway.ProcessPayment(amount);
        }
    }

    public class BankTerminal2 : IBankTerminal
    {
        private IBankTerminal2IPaymentGateway _gateway;
        public int ProcessPayment(decimal amount, string uniqueId)
        {
            if (string.IsNullOrWhiteSpace(uniqueId))
            {
                throw new ArgumentException("A client must provide a unique ID for BankTerminal2");
            }
            
            return _gateway.ProcessPayment(amount, uniqueId);
        }
    }
}
