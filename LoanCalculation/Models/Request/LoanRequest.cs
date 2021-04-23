using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculation.Models.Request
{
    public class LoanRequest
    {
        public double LoanAmount { get; set; }
        public int LoanDuration { get; set; }
        public bool IncludeAnnualInterest { get; set; }
        public bool IncludeAdministrationFee { get; set; }
    }
}
