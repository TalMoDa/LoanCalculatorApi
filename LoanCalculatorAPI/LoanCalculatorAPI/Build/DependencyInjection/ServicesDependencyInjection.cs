using LoanCalculatorAPI.Services.Loan.Customer.Implementations;
using LoanCalculatorAPI.Services.Loan.Customer.Interfaces;

namespace LoanCalculatorAPI.Build.DependencyInjection;

public static class ServicesDependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomerLoanService, CustomerLoanService>();
        return services;
    }
}