using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculation.Models.Response
{
    public class PaymentOverview
    {
        public double LoanDuration { get; set; }
        public double AnnualInterest { get; set; }
        public double LoanTotalCost { get; set; }
        public double LoanYearlyCostWithInterest { get; set; }
        public double LoanAPR { get; set; }
        public double LoanMonthlyCost { get; set; }
        public double LoanInterestFullDurationCost{ get; set; }
        public double LoanAdministrativeFeesCost { get; set; }
    }
}
