using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting.model
{
    internal class PayCard
    {
        private string cardNumber;
        private DateTime periodValidaty;
        private string CVC;
        private string residentCountry;

        public PayCard(string cardNumber, DateTime periodValidaty, string CVC, string residentCountry)
        {
            this.cardNumber = cardNumber;
            this.periodValidaty = periodValidaty;
            this.CVC = CVC;
            this.residentCountry = residentCountry;
        }
        public string GetCardNumber()
        {
            return this.cardNumber;
        }
        public DateTime GetPeriodValidaty()
        {
            return this.periodValidaty;
        }
        public string GetCVC()
        {
            return this.CVC;
        }
        public string GetResidentCountry()
        {
            return this.residentCountry;
        }
    }
}
