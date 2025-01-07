using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using LoanCalculatorAPI.Data;
using LoanCalculatorAPI.Data.Repositories.Implementations;
using LoanCalculatorAPI.Data.Repositories.Interfaces;
using LoanCalculatorAPI.Settings;

namespace LoanCalculatorAPI.Build.DependencyInjection;

public static class DataDependencyInjection
{
    public static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        var connectionString = services.BuildServiceProvider().GetRequiredService<IOptions<ConnectionStrings>>().Value
            .DefaultConnection;
        services.AddScoped<IDbConnection>(_ => new SqlConnection(connectionString));
        services.AddDbContext<FinanceDbContext>(options => options.UseSqlServer(connectionString));
        services.AddRepositories();
        return services;
    }


    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<ILoanAgeCalculationRepository, LoanAgeCalculationRepository>();
        services.AddScoped<IPrimeInterestRepository, PrimeInterestRepository>();
        return services;
    }
}