namespace SOLID.DemeterLaw.Before
{
    public class Customer
    {
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Wallet = new Wallet(1000m);
        }

        public string FirstName { get; }
        public string LastName { get; }

        public Wallet Wallet { get; }
    }

    public class PaperBoy
    {
        public void DeliverMagazine(decimal costOfMagazine, Customer customer)
        {
            Wallet w = customer.Wallet;
            if (w.MoneyAmount > costOfMagazine)
            {
                w.WithdrawMoney(costOfMagazine);
            }
            else
            {
                //come back later
            }
        }
    }
}
