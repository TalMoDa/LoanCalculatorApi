using System.Reflection;
using FluentValidation;
using MediatR;
using LoanCalculatorAPI.Pipelines;

namespace LoanCalculatorAPI.Build.DependencyInjection;

public static class MediatorDependencyInjection
{
    public static IServiceCollection AddAppMediatR(this IServiceCollection services)
    {
        services.AddMediatR(configuration => { configuration.RegisterServicesFromAssemblyContaining<Program>(); });
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}