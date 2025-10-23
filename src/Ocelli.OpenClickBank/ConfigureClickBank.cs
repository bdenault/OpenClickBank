using Microsoft.Extensions.DependencyInjection;
using Ocelli.OpenClickBank.Handlers;

namespace Ocelli.OpenClickBank;

public static class ConfigureClickBank
{
    /// <summary>
    /// Registers ClickBank services, including HttpClientFactory and the <see cref="IClickBankServiceFactory"/>.
    /// </summary>
    /// <remarks>
    /// Also allows callers to configure the <see cref="ClickBankBuilder"/> via the <paramref name="configure"/> action.
    /// </remarks>
    /// <param name="configure">Configures the <see cref="ClickBankBuilder"/></param>
    /// <returns>The <see cref="IServiceCollection"/> for chaining calls.</returns>
    public static IServiceCollection AddClickBankServices(this IServiceCollection services, Action<ClickBankBuilder>? configure = null)
    {
        // Register the delegate handler for ClickBank API calls
        services.AddTransient(sp =>
        {
            var builder = sp.GetRequiredService<ClickBankBuilder>();
            return new ClickBankDelegateHandler(sp, builder);
        });

        // Add the actual HTTP client (and factory)
        services.AddHttpClient("ClickBankClient")
            .ConfigureHttpClient(client => client.Timeout = TimeSpan.FromSeconds(30))
            .AddHttpMessageHandler<ClickBankDelegateHandler>();

        // Builds the ClickBankService
        services.AddSingleton<IClickBankServiceFactory, ClickBankServiceFactory>();

        // Registers a default instance of IClickBankService
        // TODO: Not required/recommended?
        services.AddTransient(sp =>
        {
            var factory = sp.GetRequiredService<IClickBankServiceFactory>();
            var defaultConfig = new OpenClickBankConfig(); // Provide sensible defaults
            return factory.Create(defaultConfig);
        });

        // Configure the builder
        var builder = new ClickBankBuilder();
        configure?.Invoke(builder);
        services.AddSingleton(builder);

        // For call chaining
        return services;
    }
}
