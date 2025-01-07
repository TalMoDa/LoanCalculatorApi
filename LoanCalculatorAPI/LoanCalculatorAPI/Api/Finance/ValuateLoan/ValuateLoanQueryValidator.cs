using FluentValidation;

namespace LoanCalculatorAPI.Api.Finance.ValuateLoan;

public class ValuateLoanQueryValidator : AbstractValidator<ValuateLoanQuery>
{
    
    public ValuateLoanQueryValidator()
    {
        RuleFor(x => x.LoanAmount).GreaterThan(0).WithMessage("Loan amount must be greater than 0");
        
        // Client Id is required but if later on we want to make it optional if we want to calculate the loan for a new client or based on something else lets say a business id etc...
        When(x => x.ClientId != null, () =>
        {
            RuleFor(x => x.ClientId).NotEmpty().WithMessage("Client Id is required");
        });
        
        RuleFor(x => x.LoanPeriodInMonths).GreaterThanOrEqualTo(12).WithMessage("A Minimum loan period of 12 months is required");
    }
    
}