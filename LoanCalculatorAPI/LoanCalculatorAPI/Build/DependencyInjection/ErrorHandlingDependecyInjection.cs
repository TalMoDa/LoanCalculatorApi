using Microsoft.AspNetCore.Mvc.Infrastructure;
using LoanCalculatorAPI.Factories;

namespace LoanCalculatorAPI.Build.DependencyInjection;

public static class ErrorHandlingDependencyInjection
{
    public static IServiceCollection UseProblemDetails(this IServiceCollection services)
    {
        services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
        return services;
    }
}