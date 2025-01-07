using LoanCalculatorAPI.Common.Models.ResultPattern;
using LoanCalculatorAPI.Services.Loan.Customer.Interfaces;
using MediatR;

namespace LoanCalculatorAPI.Api.Finance.ValuateLoan;

public class ValuateLoanQueryHandler(ICustomerLoanService customerLoanService) : IRequestHandler<ValuateLoanQuery, Result<decimal>>
{
    public async Task<Result<decimal>> Handle(ValuateLoanQuery request, CancellationToken cancellationToken)
    {

        if (request.ClientId.HasValue)
        {
            return await CalculateCustomerLoan(request, cancellationToken);
        }
        
        //TODO: Add more operations here like calculating loan for other types of clients like companies, etc.
        
        throw new NotSupportedException("no matching operation found for the request");
    }


    private async Task<Result<decimal>> CalculateCustomerLoan(ValuateLoanQuery request, CancellationToken cancellationToken)
    {
        return await customerLoanService.CalculateLoanAsync(
            request.ClientId!.Value,
            request.LoanAmount,
            request.LoanPeriodInMonths,
            cancellationToken);
    }
}

