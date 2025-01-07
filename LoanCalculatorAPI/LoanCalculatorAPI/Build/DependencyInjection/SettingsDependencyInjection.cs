using LoanCalculatorAPI.Settings;

namespace LoanCalculatorAPI.Build.DependencyInjection;

public static class SettingsDependencyInjection
{
    public static IServiceCollection AddSettings(this IServiceCollection services)
    {
        services.AddOptions<ConnectionStrings>().BindConfiguration(nameof(ConnectionStrings)).ValidateDataAnnotations()
            .ValidateOnStart();
        
        return services;
    }
}