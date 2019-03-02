namespace SOLID.DemeterLaw
{
    public class Wallet
    {
        public Wallet(decimal moneyAmount)
        {
            MoneyAmount = moneyAmount;
        }

        public decimal MoneyAmount { get; private set; }

        public void AddMoney(decimal amount)
        {
            MoneyAmount += amount;
        }

        public void WithdrawMoney(decimal amount)
        {
            MoneyAmount -= amount;
        }
    }
}
