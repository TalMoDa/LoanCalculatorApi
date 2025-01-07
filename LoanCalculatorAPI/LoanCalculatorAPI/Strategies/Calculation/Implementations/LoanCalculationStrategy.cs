using LoanCalculatorAPI.Data.Entities.EF;
using LoanCalculatorAPI.Data.Repositories.Interfaces;
using LoanCalculatorAPI.Helpers.Calculate;
using LoanCalculatorAPI.Strategies.Calculation.Interfaces;

namespace LoanCalculatorAPI.Strategies.Calculation.Implementations;

public class LoanCalculationStrategy(ILoanAgeCalculationRepository loanAgeCalculationRepository, IPrimeInterestRepository primeInterestRepository) : ILoanCalculationStrategy
{
    public async Task<decimal> CalculateInterestByAgeStrategy(decimal loanAmount, int loanPeriodInMonths, int age, CancellationToken cancellationToken = default)
    {
        var loanAgeCalculations = await loanAgeCalculationRepository.GetLoanAgeCalculationByAgeAndLoanAmount(age, loanAmount, cancellationToken);
        
        ValidateLoanAgeCalculations(loanAgeCalculations);

        var loanAgeCalculation = loanAgeCalculations.First();

        // Perform base interest calculation
        var baseInterest = CalculateInterestHelper.CalculateBaseInterest(loanAmount, loanAgeCalculation.InterestRate);

        // Include prime interest if applicable
        var primeInterest = loanAgeCalculation.IsWithPrimeInterest 
            ? await GetPrimeInterestRateContribution(loanAmount, cancellationToken) 
            : 0;

        // Calculate extra months interest
        var extraMonthInterest = CalculateExtraMonthInterest(loanAmount, loanPeriodInMonths, loanAgeCalculation.LoanPeriodExtraMonthInterest);

        // Total loan amount including all interest
        return loanAmount + baseInterest + primeInterest + extraMonthInterest;
    }



    private async Task<decimal> GetPrimeInterestRateContribution(decimal loanAmount, CancellationToken cancellationToken)
    {
        var primeInterestRate = await GetPrimeInterestRate(cancellationToken);
        return loanAmount * (primeInterestRate / 100);
    }

    private decimal CalculateExtraMonthInterest(decimal loanAmount, int loanPeriodInMonths, LoanPeriodExtraMonthInterest? loanAgeCalculation)
    {
        if (loanAgeCalculation is null || loanPeriodInMonths <= loanAgeCalculation.ExtraMonths)
            return 0;

        var extraMonths = loanPeriodInMonths - loanAgeCalculation.ExtraMonths;
        var extraMonthInterestRate = loanAgeCalculation.ExtraMonthInterestRate / 100;

        return loanAmount * extraMonths * extraMonthInterestRate;
    }

    private async Task<decimal> GetPrimeInterestRate(CancellationToken cancellationToken = default)
    {
        var primeInterest = await primeInterestRepository.GetActivePrimeInterestAsync(cancellationToken);
        ArgumentNullException.ThrowIfNull(primeInterest, "Cannot find any active prime interest rate so cannot calculate the interest for the client");
        return primeInterest.InterestRate;
    }

    private void ValidateLoanAgeCalculations(List<LoanAgeCalculation> loanAgeCalculations)
    {
        ArgumentOutOfRangeException.ThrowIfZero(loanAgeCalculations.Count, "Cannot find the right loan to calculate the interest for the client");
        ArgumentOutOfRangeException.ThrowIfGreaterThan(1, loanAgeCalculations.Count, "Cannot find the right loan to calculate the interest for the client");
    }
}
