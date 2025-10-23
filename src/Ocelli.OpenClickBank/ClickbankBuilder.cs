namespace Ocelli.OpenClickBank;

public class ClickbankBuilder
{
    internal ClickbankBuilder() { }

    public Func<IServiceProvider, HttpResponseMessage, CancellationToken, Task>? ProcessOrderResponse { get; set; }
}
