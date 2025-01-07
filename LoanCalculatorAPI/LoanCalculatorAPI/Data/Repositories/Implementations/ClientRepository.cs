using Microsoft.EntityFrameworkCore;
using LoanCalculatorAPI.Data.Entities.EF;
using LoanCalculatorAPI.Data.Repositories.Interfaces;

namespace LoanCalculatorAPI.Data.Repositories.Implementations;

public class ClientRepository(FinanceDbContext context) : BaseRepository<Client>(context), IClientRepository;