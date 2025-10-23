using Microsoft.Extensions.DependencyInjection;
using Ocelli.OpenClickBank;

var serviceProvider = new ServiceCollection()
    .AddLogging()
    .AddClickBankServices(builder => // Register ClickBank Services
    {
        builder.OnResponse(HttpMethod.Get, "/rest/1.3/quickstats/accounts", async (sp, res, ct) =>
        {
            var content = await res.Content.ReadAsStringAsync(ct);
            Console.WriteLine($"  Received response: {content}");
        });
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
    var quickstats = await clickBankService.Quickstats.GetQuickstatAccountsAsync();

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