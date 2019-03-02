namespace SOLID.DIP
{
    public interface ICustomer
    {
    }

    public class Customer : ICustomer
    {
        private readonly ICustomerRepository _customerRepository;

        public Customer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
    }

    public class DbGateway : IDbGateway
    {
    }

    public interface IDbGateway
    {
    }

    class CustomerRepository : ICustomerRepository
    {
        private IDbGateway gateway;

        public CustomerRepository(IDbGateway gateway)
        {
            this.gateway = gateway;
        }
    }

    public interface ICustomerRepository
    {
    }
   

    public class MainViewModel
    {
        public ICustomer Customer { get; set; }

        public MainViewModel(ICustomer customer)
        {
            Customer = customer;
        }
    }
}
