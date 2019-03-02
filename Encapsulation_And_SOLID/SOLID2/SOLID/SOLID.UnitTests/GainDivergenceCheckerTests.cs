using NUnit.Framework;
using NUnit.Framework.Internal;
using SOLID.DIP;

namespace SOLID.UnitTests
{
    [TestFixture]
    public class GainDivergenceCheckerTests
    {
        [Test]
        [TestCase(100, 100, 100, 100, true)]
        [TestCase(100, 200, 100, 200, true)]
        [TestCase(50, 100, 50, 100, true)]
        [TestCase(50, 100, 50, 50, false)]
        [TestCase(100, 100, 50, 50, false)]
        public void HasDivergence_ReturnsCorrectResult(
                        decimal accounterSales, decimal accounterReturned,
                        decimal frSales, decimal frReturned, bool expectedResult)
        {
            IAccounter accounter = new TestableAccounter()
            {
                SalesSumm = accounterSales,
                SummOfReturnedTickets = accounterReturned
            };
            IFiscalRegistrator fr = new TestableFr()
            {
                SalesSumm = frSales,
                SummOfReturnedTickets = frReturned
            };
            var checker = new GainDivergenceChecker(accounter, fr);
            bool result = checker.HasDivergence();

            Assert.AreEqual(expectedResult, result);
        }

    }

    public class TestableAccounter : IAccounter
    {
        public decimal SalesSumm { get; set; }
        public decimal SummOfReturnedTickets { get; set; }

        public decimal GetSalesSumm()
        {
            return SalesSumm;
        }

        public decimal GetSummOfReturnedTickets()
        {
            return SummOfReturnedTickets;
        }
    }

    public class TestableFr :IFiscalRegistrator
    {
        public decimal SalesSumm { get; set; }
        public decimal SummOfReturnedTickets { get; set; }

        public decimal GetSalesSumm()
        {
            return SalesSumm;
        }

        public decimal GetSummOfReturnedTickets()
        {
            return SummOfReturnedTickets;
        }
    }
}
