using Microsoft.Extensions.DependencyInjection;
using Ocelli.OpenClickBank.Handlers;

namespace Ocelli.OpenClickBank;

public static class ConfigureClickBank
{
    /// <summary>
    /// Registers ClickBank services, including HttpClientFactory and the ClickBankService factory.
    /// </summary>
    public static IServiceCollection AddClickBankServices(this IServiceCollection services)
    {
        services.AddClickBankServiceInternal();

        return services;
    }

    public static IServiceCollection AddClickBankServices(this IServiceCollection services, Action<ClickbankBuilder>? configure = null)
    {
        var builder = new ClickbankBuilder();
        configure?.Invoke(builder);

        services.AddClickBankServiceInternal(builder: builder);

        return services;
    }

    private static IServiceCollection AddClickBankServiceInternal(this IServiceCollection services, ClickbankBuilder? builder = null)
    {
        services.AddTransient(sp =>
        {
            var buider = sp.GetService<ClickbankBuilder>();
            builder ??= new();
            return new ClickbankDelegateHandler(sp, builder);
        });

        services.AddHttpClient("ClickBankClient")
            .ConfigureHttpClient(client => client.Timeout = TimeSpan.FromSeconds(30))
            .AddHttpMessageHandler<ClickbankDelegateHandler>();

        services.AddSingleton<IClickBankServiceFactory, ClickBankServiceFactory>();

        // Optionally, allow injecting ClickBankService directly
        services.AddTransient(sp =>
        {
            var factory = sp.GetRequiredService<IClickBankServiceFactory>();
            var defaultConfig = new OpenClickBankConfig(); // Provide sensible defaults
            return factory.Create(defaultConfig);
        });

        if (builder is not null) services.AddSingleton(builder);

        return services;
    }
}
