namespace SOLID.DemeterLaw.After
{
    public class Customer
    {
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            wallet = new Wallet(1000m);
        }

        public string FirstName { get; }
        public string LastName { get; }

        private readonly Wallet wallet;

        public decimal GetPayment(decimal amount)
        {
            if (wallet.MoneyAmount >= amount)
            {
                wallet.WithdrawMoney(amount);
                return amount;
            }
            return 0;
        }
    }

    public class PaperBoy
    {
        public void DeliverMagazine(decimal costOfMagazine, Customer customer)
        {
            decimal payment = customer.GetPayment(costOfMagazine);
            if (payment == costOfMagazine)
            {
                //say thank you and get out
            }
            else
            {
                //come back later
            }
        }
    }
}
