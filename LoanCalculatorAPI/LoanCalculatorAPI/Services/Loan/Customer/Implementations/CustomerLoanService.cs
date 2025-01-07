using LoanCalculatorAPI.Common.Models.ResultPattern;
using LoanCalculatorAPI.Data.Repositories.Interfaces;
using LoanCalculatorAPI.Services.Loan.Customer.Interfaces;
using LoanCalculatorAPI.Strategies.Calculation.Interfaces;

namespace LoanCalculatorAPI.Services.Loan.Customer.Implementations;

public class CustomerLoanService(ILoanCalculationStrategy loanCalculationStrategy, IClientRepository clientRepository) : ICustomerLoanService
{
    
    public async Task<Result<decimal>> CalculateLoanAsync(Guid customerId, decimal loanAmount, int loanPeriodInMonths, CancellationToken cancellationToken)
    {
        var client = await clientRepository.GetAsync(customerId, cancellationToken);
        
        if(client is null)
        {
           return Error.NotFound($"Client with id {customerId} was not found");
        }
        
        var loanValue = await loanCalculationStrategy.CalculateInterestByAgeStrategy(
            loanAmount: loanAmount,
            loanPeriodInMonths: loanPeriodInMonths, 
            age: client.Age,
            cancellationToken);
        
        return loanValue;
    }

}