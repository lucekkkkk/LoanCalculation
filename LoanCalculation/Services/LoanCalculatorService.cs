using LoanCalculation.Enum;
using LoanCalculation.Helpers;
using LoanCalculation.Models.Request;
using LoanCalculation.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculation.Services
{
    public class LoanCalculatorService
    {
        private readonly ICalculateHelper _calculateHelper;
        private readonly IFormatHelper _formatHelper;

        public LoanCalculatorService(ICalculateHelper calculateHelper, IFormatHelper formatHelper)
        {
            _calculateHelper = calculateHelper;
            _formatHelper = formatHelper;
        }

        public PaymentOverview GeneratePaymentOverview(LoanRequest request)
        {
            var pOverview = new PaymentOverview();

            pOverview.LoanMonthlyCost = _calculateHelper.MonthlyCost(request.LoanDuration, request.LoanAmount, request.IncludeAnnualInterest);
            pOverview.LoanAdministrativeFeesCost = _calculateHelper.TotalAdministrationFee(request.LoanAmount, request.IncludeAdministrationFee);
            pOverview.LoanYearlyCostWithInterest = _calculateHelper.YearlyCostWithInterest(pOverview.LoanMonthlyCost);
            pOverview.LoanAPR = _calculateHelper.RealAPR(request.LoanDuration, request.LoanAmount, pOverview.LoanAdministrativeFeesCost, request.IncludeAnnualInterest);
            pOverview.LoanTotalCost = _calculateHelper.LoanTotalCost(pOverview.LoanMonthlyCost, request.LoanDuration, pOverview.LoanAdministrativeFeesCost);
            pOverview.LoanInterestFullDurationCost = _calculateHelper.TotalAmountPaidInInterest(pOverview.LoanTotalCost, pOverview.LoanAdministrativeFeesCost, request.LoanAmount);
            pOverview.LoanInterestFullDurationCost = pOverview.LoanInterestFullDurationCost;

            pOverview.AnnualInterest = request.IncludeAnnualInterest ? InterestRates.AnnualInterestRate : 0;

            _formatHelper.FormatPaymentOverview(pOverview);

            return pOverview;
        }
    }
}
