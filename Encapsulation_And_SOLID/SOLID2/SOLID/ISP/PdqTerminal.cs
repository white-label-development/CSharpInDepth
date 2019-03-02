using System;
using System.Runtime.InteropServices;

namespace SOLID.ISP
{
    public class PdqTerminal : IBankTerminal, IReadersCommunicable
    {
        private PdqTerminalServiceCommunicator _service = new PdqTerminalServiceCommunicator();

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
        public bool IsContactReaderOnPort(string comPort)
        {
            return _service.IsContactReaderOnPort(comPort);
        }

        public bool IsNonContactReaderOnPort(string comPort)
        {
            return _service.IsNonContactReaderOnPort(comPort);
        }

        public string FindContactReader()
        {
            return _service.FindContactReader();
        }

        public string FindNonContactReader()
        {
            return _service.FindNonContactReader();
        }
    }

    /// <summary>
    /// Communicates with ZapTerminal COM-server
    /// </summary>
    public class PdqTerminalServiceCommunicator
    {
        private IPdqServiceWrapper _serviceWrapper;
        public bool IsContactReaderOnPort(string comPort)
        {
            return _serviceWrapper.IsContactReaderOnPort(comPort);
        }

        public bool IsNonContactReaderOnPort(string comPort)
        {
            return _serviceWrapper.IsNonContactReaderOnPort(comPort);
        }

        public string FindContactReader()
        {
            return _serviceWrapper.FindContactReader();
        }

        public string FindNonContactReader()
        {
            return _serviceWrapper.FindNonContactReader();
        }
    }

    [Guid("9E13876D-EDE8-4B1B-BE89-B8497B693C6B")]
    [ComImport]
    public interface IPdqServiceWrapper
    {
        bool IsContactReaderOnPort(string comPort);
        bool IsNonContactReaderOnPort(string comPort);
        string FindContactReader();
        string FindNonContactReader();
    }
}