using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ocelli.OpenClickBank;

var serviceProvider = new ServiceCollection()
    .AddClickBankServices() // Register ClickBank Services
    .BuildServiceProvider();

var serviceProvider2 = new ServiceCollection()
    .AddLogging()
    .AddClickBankServices(builder =>
    {
        builder.ProcessOrderResponse = async (sp, res, ct) =>
        {
            var logger = sp.GetRequiredService<ILoggerFactory>().CreateLogger("ProcessOrderResponse");
            var content = await res.Content.ReadAsStringAsync(ct);
            logger.LogDebug("{Content}", content);
        };
    })
    .BuildServiceProvider();

// Get the Factory
var factory = serviceProvider.GetRequiredService<IClickBankServiceFactory>();

// Prompt user for API Keys (Simulating App Registration)
Console.Write("Enter Clerk API Key: ");
var clerkKey = Console.ReadLine()?.Trim() ?? string.Empty;

var config = new OpenClickBankConfig(clerkKey);

// Create a ClickBank Service using the factory
var clickBankService = factory.Create(config);

// Perform an API call (Example: Fetch Quickstats)
try
{
    Console.WriteLine("Fetching Quickstats...");
    var quickstats = clickBankService.Quickstats.GetQuickstatAccountsAsync().Result;

    if (quickstats?.AccountData != null)
    {
        foreach (var account in quickstats.AccountData)
        {
            Console.WriteLine($"Account: {account.NickName}");
        }
    }
    else
    {
        Console.WriteLine("No accounts found.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error fetching Quickstats: {ex.Message}");
}