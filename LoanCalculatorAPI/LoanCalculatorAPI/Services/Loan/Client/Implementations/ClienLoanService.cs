using LoanCalculatorAPI.Common.Models.ResultPattern;
using LoanCalculatorAPI.Data.Repositories.Interfaces;
using LoanCalculatorAPI.Services.Loan.Calculations.Interfaces;
using LoanCalculatorAPI.Services.Loan.Client.Interfaces;

namespace LoanCalculatorAPI.Services.Loan.Client.Implementations;

public class ClientLoanService(ILoanCalculationService loanCalculationService, IClientRepository clientRepository) : IClientLoanService
{
    
    public async Task<Result<decimal>> CalculateLoanAsync(Guid customerId, decimal loanAmount, int loanPeriodInMonths, CancellationToken cancellationToken)
    {
        var client = await clientRepository.GetAsync(customerId, cancellationToken);
        
        if(client is null)
        {
           return Error.NotFound($"Client with id {customerId} was not found");
        }
        
        var loanValue = await loanCalculationService.CalculateInterestAsync(
            loanAmount: loanAmount,
            loanPeriodInMonths: loanPeriodInMonths, 
            age: client.Age,
            cancellationToken);
        
        return loanValue;
    }

}