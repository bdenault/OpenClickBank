using Ocelli.OpenClickBank.Handlers;

namespace Ocelli.OpenClickBank;

public class ClickbankBuilder
{
    internal ClickbankBuilder() { }

    private readonly HandlerRegistry _requests = new();
    private readonly HandlerRegistry _responses = new();

    public ClickbankBuilder OnRequest(HttpMethod method, string template, Func<IServiceProvider, HttpRequestMessage, CancellationToken, Task> handler)
    {
        _requests.Add(method, template, handler);
        return this;
    }

    public ClickbankBuilder OnResponse(HttpMethod method, string template, Func<IServiceProvider, HttpResponseMessage, CancellationToken, Task> handler)
    {
        _responses.Add(method, template, handler);
        return this;
    }

    internal HandlerRegistry Requests => _requests;
    internal HandlerRegistry Responses => _responses;
}
