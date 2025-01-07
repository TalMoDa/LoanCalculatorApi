using LoanCalculatorAPI.Data.Entities.EF;
using LoanCalculatorAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LoanCalculatorAPI.Data.Repositories.Implementations;

public class LoanAgeCalculationRepository(FinanceDbContext context) : BaseRepository<LoanAgeCalculation>(context), ILoanAgeCalculationRepository
{
    public Task<List<LoanAgeCalculation>> GetLoanAgeCalculationByAgeAndLoanAmount(int age, decimal loanAmount,
        CancellationToken cancellationToken = default)
    {
        return _context.LoanAgeCalculations
            .AsNoTracking()
            .Where(x => 
                x.MinAge <= age && x.MaxAge >= age
                                && x.LoanMinAmount <= loanAmount 
                                && (x.LoanMaxAmount == null || x.LoanMaxAmount >= loanAmount)) // Handle NULL AS Max
            .Include(x => x.LoanPeriodExtraMonthInterest)
            .ToListAsync(cancellationToken);
        
    }
}