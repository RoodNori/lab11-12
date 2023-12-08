using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.model;

namespace WebTesting.utils
{
    internal class CardGenerator
    {
        public static PayCard GetRestrictedCard()
        {
            DateTime Date = new DateTime(2027, 5, 27);

            return new PayCard("4356238947128094", Date, "228", "Беларусь");
        }
    }
}
