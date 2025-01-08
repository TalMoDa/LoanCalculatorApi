using LoanCalculatorAPI.Services.Loan.Calculations.Implementations;
using LoanCalculatorAPI.Services.Loan.Calculations.Interfaces;
using LoanCalculatorAPI.Services.Loan.Client.Implementations;
using LoanCalculatorAPI.Services.Loan.Client.Interfaces;

namespace LoanCalculatorAPI.Build.DependencyInjection;

public static class ServicesDependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IClientLoanService, ClientLoanService>();
        services.AddScoped<ILoanCalculationService, LoanCalculationService>();
        return services;
    }
}