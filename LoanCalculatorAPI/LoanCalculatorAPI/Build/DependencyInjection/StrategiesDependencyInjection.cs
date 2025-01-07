using LoanCalculatorAPI.Strategies.Calculation.Implementations;
using LoanCalculatorAPI.Strategies.Calculation.Interfaces;

namespace LoanCalculatorAPI.Build.DependencyInjection;

public static class StrategiesDependencyInjection
{
    public static IServiceCollection AddStrategies(this IServiceCollection services)
    {
        services.AddScoped<ILoanCalculationStrategy, LoanCalculationStrategy>();
        return services;
    }

}