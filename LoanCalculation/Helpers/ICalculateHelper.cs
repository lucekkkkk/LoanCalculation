using LoanCalculation.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculation.Helpers
{
    public interface ICalculateHelper
    {
        double MonthlyCost(int loanDuration, double loanAmount, bool includeAnnualInterest = false);
        double TotalAdministrationFee(double loanAmount, bool includeAdministrationFee = false);
        double YearlyCostWithInterest(double monthlyCost);
        double RealAPR(int loanDuration, double loanAmount, double administrationFee, bool includeAnnualInterest = false);
        double LoanTotalCost(double monthlyCost, int loanDuration, double administrationFee);
        double TotalAmountPaidInInterest(double loanTotalCost, double administrationFee, double loanAmount);
    }
}
