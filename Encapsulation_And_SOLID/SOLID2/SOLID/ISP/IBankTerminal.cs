using System;

namespace SOLID.ISP
{
    public interface IBankTerminal
    {
        void Start();
        void Stop();
        void Ping();
        void BankHostTest();
        void Purchase(decimal amount, string checkId);
        void CancelPayment(string checkId, decimal amount);
        void InterruptTransaction();

        event EventHandler<PaymentOperationCompletedEventArgs> PaymentCompleted;
        event EventHandler<PaymentOperationCompletedEventArgs> CancellationCompleted;
        event EventHandler<TransactionCompletedEventArgs> TransactionCompleted;

    }

    public interface IReadersCommunicable
    {
        bool IsContactReaderOnPort(string comPort);
        bool IsNonContactReaderOnPort(string comPort);
        string FindContactReader();
        string FindNonContactReader();
    }

    public class TransactionCompletedEventArgs : EventArgs
    {
    }

    public class PaymentOperationCompletedEventArgs : EventArgs
    {
    }
}
