using LoanCalculatorAPI.Common.Models.ResultPattern;

namespace LoanCalculatorAPI.Services.Loan.Customer.Interfaces;

public interface ICustomerLoanService 
{
    Task<Result<decimal>> CalculateLoanAsync(Guid customerId, decimal loanAmount, int loanPeriodInMonths,CancellationToken cancellationToken = default);
}