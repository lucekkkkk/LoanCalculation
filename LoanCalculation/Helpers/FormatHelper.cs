using LoanCalculation.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculation.Helpers
{
    public class FormatHelper : IFormatHelper
    {
        public double RoundResult(double value)
        {
            return Math.Round(value, 2);
        }

        public PaymentOverview FormatPaymentOverview(PaymentOverview paymentOverview)
        {
            foreach (var prop in paymentOverview.GetType().GetProperties())
            {
                var value = prop.GetValue(paymentOverview, null);
                prop.SetValue(paymentOverview, RoundResult((double)value), null);
            }

            return paymentOverview;
        }
    }
}
