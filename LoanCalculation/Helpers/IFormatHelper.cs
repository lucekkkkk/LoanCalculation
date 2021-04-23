using LoanCalculation.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculation.Helpers
{
    public interface IFormatHelper
    {
        double RoundResult(double value);
        PaymentOverview FormatPaymentOverview(PaymentOverview paymentOverview);
    }
}
