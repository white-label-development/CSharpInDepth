using System;
using SOLID.ISP;
using SOLID.Maybe;
using SOLID.Monads;

namespace SOLID.Encapsulation
{
    public class Customer
    {
        public event EventHandler<Customer> CustomerReceived;
        public string PaySalary(string amount)
        {
            //impl.
            return null;
        }

        public void GetCustomer(int id)
        {
            //impl.
        }

        public int RemoveCustomer(int id)
        {
            //impl.
            return 0;
        }
    }

    public class EncapsulatedCustomer
    {
        public void PaySalary(decimal amount)
        {
        }

        public EncapsulatedCustomer GetCustomer(int id)
        {
            //impl.
            return null;
        }

        public void RemoveCustomer(int id)
        {
            //impl.
        }
    }

    public class EncapsulatedCustomer2
    {
        public Result PaySalary(decimal amount)
        {
            return Result.Success();
        }

        public Maybe<EncapsulatedCustomer2> GetCustomer(int id)
        {
            //get instance from a DB
            var customer = new EncapsulatedCustomer2();
            return Maybe<EncapsulatedCustomer2>.From(customer);
        }

        public Result RemoveCustomer(int id)
        {
            return Result.Success();
        }
    }

    public class Persister : IReader, IWriter
    {
        public byte[] Read(string file)
        {
            return new byte[] {0x00};
        }

        public void Write(byte[] content)
        {
            
        }
    }

    public interface IReader
    {
        byte[] Read(string file);
    }
    public interface IWriter
    {        
        void Write(byte[] content);
    }
}
