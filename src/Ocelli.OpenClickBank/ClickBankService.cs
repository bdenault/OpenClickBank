﻿namespace Ocelli.OpenClickBank;

//TODO: add a method to return a flag if a list has more records (206 response)
public partial class ClickBankService : IClickBankService
{
    protected static HttpClient? HttpClient;
    private OpenClickBankConfig? _openClickBankConfig;

    public ClickBankService(string developerApiKey, string clerkApiKey) => OpenClickBankConfig = new OpenClickBankConfig(developerApiKey, clerkApiKey);
    public ClickBankService(OpenClickBankConfig clickBankConfig) => OpenClickBankConfig = clickBankConfig;
    public ClickBankService() => OpenClickBankConfig = new OpenClickBankConfig();

    public IAnalyticsClient Analytics => new AnalyticsClient(HttpClient!);
    public IDebugClient Debugs => new DebugClient(HttpClient!);
    public IImageClient Images => new ImageClient(HttpClient!);
    public INotificationService Notifications => new NotificationService();
    public IOrdersClient Orders => new OrdersClient(HttpClient!);
    public IProductClient Products => new ProductClient(HttpClient!);
    public IShippingClient Shipping => new ShippingClient(HttpClient!);
    public ITicketClient Tickets => new TicketClient(HttpClient!);
    public IQuickstatsClient Quickstats => new QuickstatsClient(HttpClient!);

    public OpenClickBankConfig OpenClickBankConfig
    {
        get => _openClickBankConfig ?? new OpenClickBankConfig();
        set
        {
            //TODO: Add rate limiting to 10 calls per second.
            HttpClient = new HttpClient();
            _openClickBankConfig = value;
            HttpClient.Timeout = _openClickBankConfig.HttpTimeout;
            var credentials = $"{_openClickBankConfig.DeveloperApiKey}:{_openClickBankConfig.ClerkApiKey}";
            HttpClient.DefaultRequestHeaders.Clear();
            do
            {
                try
                {
                    HttpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", credentials);
                    break;
                }
                catch (Exception)
                {
                    //There can be concurrent locks, just keep trying.
                    Thread.Sleep(new Random().Next(3, 10) * 1000);
                }
            } while (true);
        }
    }
}