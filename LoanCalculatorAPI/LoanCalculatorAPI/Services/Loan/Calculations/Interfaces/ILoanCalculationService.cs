namespace LoanCalculatorAPI.Services.Loan.Calculations.Interfaces;

public interface ILoanCalculationService 
{
    Task<decimal> CalculateInterestAsync(decimal loanAmount, int loanPeriodInMonths, int age, CancellationToken cancellationToken = default);
}