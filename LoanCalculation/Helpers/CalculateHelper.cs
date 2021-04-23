using LoanCalculation.Enum;
using LoanCalculation.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculation.Helpers
{
    public class CalculateHelper : ICalculateHelper
    {
        public double MonthlyCost(int loanDuration, double loanAmount, bool includeAnnualInterest = false)
        {
            double monthlyCost = 0;
            double loanDurationMonths = loanDuration * 12;

            if (includeAnnualInterest)
            {
                double interestRateMonthly = InterestRates.AnnualInterestRate / 100 / 12; 

                monthlyCost = (loanAmount * interestRateMonthly * Math.Pow(1 + interestRateMonthly, loanDurationMonths)) / (Math.Pow(1 + interestRateMonthly, loanDurationMonths) - 1);

                return monthlyCost;
            }

            monthlyCost = loanAmount / (loanDuration * 12);

            return monthlyCost;
        }

        public double TotalAdministrationFee(double loanAmount, bool includeAdministrationFee = false)
        {
            if (!includeAdministrationFee)
            {
                return 0;
            }

            double AdministrationFeeForAmount = loanAmount * AdministrationFee.Percentage;

            if (AdministrationFeeForAmount > AdministrationFee.Constant)
                return AdministrationFee.Constant;

            return AdministrationFeeForAmount;
        }

        public double YearlyCostWithInterest(double monthlyCost)
        {
            return monthlyCost * 12.0;
        }

        public double RealAPR(int loanDuration, double loanAmount, double administrationFee, bool includeAnnualInterest = false)
        {

            double years = loanDuration;

            double interestRate = 0;

            if(administrationFee > 0)
            {
                interestRate += administrationFee / (loanAmount * years);
            }

            if(includeAnnualInterest == true)
            {
                interestRate += InterestRates.AnnualInterestRate / 100;
            }

            double apr = (Math.Pow((1.0 + (interestRate/ years)), years) - 1.0) * 100;

            return apr;
        }

        public double LoanTotalCost(double monthlyCost, int loanDuration, double administrationFee)
        {
            double totalCost = 0;
            double months = 12.0;

            totalCost = monthlyCost * loanDuration * months + administrationFee;

            return totalCost;

        }

        public double TotalAmountPaidInInterest(double loanTotalCost, double administrationFee, double loanAmount)
        {
            double totalAmountPaidInInterest = 0;

            totalAmountPaidInInterest = loanTotalCost - administrationFee - loanAmount;

            return totalAmountPaidInInterest;
        }
    }
}
