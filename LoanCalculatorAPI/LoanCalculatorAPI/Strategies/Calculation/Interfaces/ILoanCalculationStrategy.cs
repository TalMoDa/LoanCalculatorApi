namespace LoanCalculatorAPI.Strategies.Calculation.Interfaces;

public interface ILoanCalculationStrategy 
{
    Task<decimal> CalculateInterestByAgeStrategy(decimal loanAmount, int loanPeriodInMonths, int age, CancellationToken cancellationToken = default);
}