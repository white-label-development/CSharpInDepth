using System;
using SOLID.DIP;

namespace SOLID
{
    public class PaymentProcessor
    {
        public void Charge(decimal amount)
        {
            //initialize bank terminal
            //send a "ChargeCard" request to the terminal
        }

        public string CreateReport()
        {
            //format a report
            return string.Empty;
        }

        public void PrintReport()
        {
            //initialize printer's driver 
            //send a printing command
        }

        public void SavePayment()
        {
            //saving to DB
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SimpleIoC ioc = new SimpleIoC();
            ioc.Register<MainViewModel, MainViewModel>();
            ioc.Register<ICustomer, Customer>();
            ioc.Register<ICustomerRepository, CustomerRepository>();
            ioc.Register<IDbGateway, DbGateway>();

            var mainViewModel = ioc.Resolve<MainViewModel>();

            Console.ReadLine();
        }
    }
}
