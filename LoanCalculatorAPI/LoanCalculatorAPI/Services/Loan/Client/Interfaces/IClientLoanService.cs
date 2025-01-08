using LoanCalculatorAPI.Common.Models.ResultPattern;

namespace LoanCalculatorAPI.Services.Loan.Client.Interfaces;

public interface IClientLoanService 
{
    Task<Result<decimal>> CalculateLoanAsync(Guid customerId, decimal loanAmount, int loanPeriodInMonths,CancellationToken cancellationToken = default);
}