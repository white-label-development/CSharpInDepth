namespace SOLID.OCP
{
    public abstract class PaymentProcessor
    {
        public void ProcessTransaction()
        {
            WithdrawMoney();
            CalculateBonus();
            SendGreetings();
        }

        protected abstract void WithdrawMoney();
        protected abstract void CalculateBonus();
        protected abstract void SendGreetings();
    }

    public class OnlineProcessor : PaymentProcessor
    {
        protected override void WithdrawMoney() { }

        protected override void CalculateBonus() { }

        protected override void SendGreetings() { }
    }

    public class PosTerminalProcessor : PaymentProcessor
    {
        protected override void WithdrawMoney() { }

        protected override void CalculateBonus() { }

        protected override void SendGreetings() { }
    }
}
