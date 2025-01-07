using LoanCalculatorAPI.Data.Entities.EF;
using LoanCalculatorAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LoanCalculatorAPI.Data.Repositories.Implementations;

public class PrimeInterestRepository(FinanceDbContext context) : BaseRepository<PrimeInterest>(context), IPrimeInterestRepository
{
    public Task<PrimeInterest?> GetActivePrimeInterestAsync(CancellationToken cancellationToken = default)
    {
        return _context.PrimeInterests
            .Where(x => x.IsActive)
            .FirstOrDefaultAsync(cancellationToken);
    }
}