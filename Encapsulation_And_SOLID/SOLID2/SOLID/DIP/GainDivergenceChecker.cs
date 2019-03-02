using System;

namespace SOLID.DIP
{
    public class GainDivergenceChecker
    {
        private IAccounter _privateAccounter;
        private IFiscalRegistrator _fr;
        
        public GainDivergenceChecker(IAccounter accounter, IFiscalRegistrator fr)
        {
            _privateAccounter = accounter;
            _fr = fr;
        }
      
        public bool HasDivergence()
        {                        
            decimal salesSumm = _privateAccounter.GetSalesSumm();
            decimal summOfReturnedTickets = _privateAccounter.GetSummOfReturnedTickets();
                        
            decimal salesSummByFiscalRegistrator = _fr.GetSalesSumm();
            decimal summOfReturnedTicketsByFiscalRegistrator = _fr.GetSummOfReturnedTickets();

            return salesSumm == salesSummByFiscalRegistrator &&
                   summOfReturnedTickets == summOfReturnedTicketsByFiscalRegistrator;
        }

        private void ValidateDependencies(Accounter accounter, FiscalRegistrator fr)
        {
            if (accounter == null)
                throw new ArgumentNullException("accounter");
            if (fr == null)
                throw new ArgumentNullException("fr");
        }
    }

    public interface IFiscalRegistrator
    {
        decimal GetSalesSumm();
        decimal GetSummOfReturnedTickets();
    }

    public class FiscalRegistrator : IFiscalRegistrator
    {
        public decimal GetSalesSumm()
        {
            return 0;
        }

        public decimal GetSummOfReturnedTickets()
        {
            return 0;
        }
    }

    public interface IAccounter
    {
        decimal GetSalesSumm();
        decimal GetSummOfReturnedTickets();
    }

    public class Accounter : IAccounter
    {
        public decimal GetSalesSumm()
        {
            return 0;
        }

        public decimal GetSummOfReturnedTickets()
        {
            return 0;
        }
    }
}
