using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.LSP.Violation
{
    class Customer
    {
        
    }

    class PrivelegedCustomer : Customer
    {
        public void AddMoneyToAccount(decimal amount)
        {            
        }
    }

    class Downcast
    {
        private ICustomerRepo repository;

        public void PayCashback(int customerId, decimal amount)
        {
            Customer c = repository.GetCustomer(customerId);
            var pc = c as PrivelegedCustomer;
            if (pc != null)
            {
                pc.AddMoneyToAccount(amount);
            }
            else
            {
                throw new ArgumentException("PayCashback on a regular customer!");
            }
        }
    }

    internal interface ICustomerRepo
    {
        Customer GetCustomer(int customerId);
    }
}
