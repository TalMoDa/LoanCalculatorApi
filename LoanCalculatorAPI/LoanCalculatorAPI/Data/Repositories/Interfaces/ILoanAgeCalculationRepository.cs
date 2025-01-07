using LoanCalculatorAPI.Data.Entities.EF;

namespace LoanCalculatorAPI.Data.Repositories.Interfaces;

public interface ILoanAgeCalculationRepository : IBaseRepository<LoanAgeCalculation>
{
    Task<List<LoanAgeCalculation>> GetLoanAgeCalculationByAgeAndLoanAmount(int age, decimal loanAmount,
        CancellationToken cancellationToken = default);
}