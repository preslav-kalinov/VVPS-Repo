using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVPS_Exercise4
{
    public class PaymentDates
    {
        public DateTime CalculateFuturePaymentDate(DateTime startingDate)
        {
            var tempDate = startingDate.AddDays(30);

            switch (tempDate.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    tempDate = tempDate.AddDays(2);
                    break;
                case DayOfWeek.Sunday:
                    tempDate = tempDate.AddDays(3);//Error here
                    break;
            }
            return tempDate;
        }
    }
}
