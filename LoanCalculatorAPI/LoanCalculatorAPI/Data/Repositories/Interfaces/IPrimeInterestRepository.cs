using LoanCalculatorAPI.Data.Entities.EF;

namespace LoanCalculatorAPI.Data.Repositories.Interfaces;

public interface IPrimeInterestRepository : IBaseRepository<PrimeInterest>
{
    Task<PrimeInterest?> GetActivePrimeInterestAsync(CancellationToken cancellationToken = default);
}