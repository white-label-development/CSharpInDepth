using System;

namespace SOLID.ISP
{
    public class ZonTerminal : IBankTerminal
    {
        public void Start()
        {
        }

        public void Stop()
        {
        }

        public void Ping()
        {
        }

        public void BankHostTest()
        {
        }

        public void Purchase(decimal amount, string checkId)
        {
        }

        public void CancelPayment(string checkId, decimal amount)
        {
        }

        public void InterruptTransaction()
        {
        }

        public event EventHandler<PaymentOperationCompletedEventArgs> PaymentCompleted;
        public event EventHandler<PaymentOperationCompletedEventArgs> CancellationCompleted;
        public event EventHandler<TransactionCompletedEventArgs> TransactionCompleted;       
    }
}