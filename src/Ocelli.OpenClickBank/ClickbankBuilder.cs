using Ocelli.OpenClickBank.Handlers;

namespace Ocelli.OpenClickBank;

/// <summary>
/// Provides a builder for configuring request and response handlers for Clickbank operations.
/// </summary>
/// <remarks>
/// Allows the registration of handlers for specific HTTP methods and URL templates, enabling
/// custom processing of HTTP requests and responses.<br/><br/>
/// Response handlers occur before any deserialization of the response.
/// </remarks>
public class ClickBankBuilder
{
    internal ClickBankBuilder() { }

    private readonly HandlerRegistry _requestHandlers = new();
    private readonly HandlerRegistry _responseHandlers = new();

    /// <summary>
    /// Registers a new request handler for the provided <paramref name="method"/>/<paramref name="template"/> combination.
    /// </summary>
    /// <remarks>
    /// The <paramref name="template"/> string should be the template, not the specific route.<br/>
    /// For example, to add a handler for the get order by receipt endpoint:<br/>
    /// <c>OnRequest(HttpMethod.Get, "/rest/1.3/orders/{receipt}", handler)</c>
    /// </remarks>
    /// <param name="method">From <see cref="HttpMethod"/>, should match ClickBank docs.</param>
    /// <param name="template">Templated route as per ClickBank docs.</param>
    /// <param name="handler">The actual function to run before sending the request.</param>
    /// <returns>The <see cref="ClickBankBuilder"/> for chaining calls.</returns>
    public ClickBankBuilder OnRequest(HttpMethod method, string template, Func<IServiceProvider, HttpRequestMessage, CancellationToken, Task> handler)
    {
        _requestHandlers.Add(method, template, handler);
        return this;
    }

    /// <summary>
    /// Registers a new response handler for the provided <paramref name="method"/>/<paramref name="template"/> combination.
    /// </summary>
    /// <remarks>
    /// The <paramref name="template"/> string should be the template, not the specific route.<br/>
    /// For example, to add a handler for the get order by receipt endpoint:<br/>
    /// <c>OnResponse(HttpMethod.Get, "/rest/1.3/orders/{receipt}", handler)</c>
    /// </remarks>
    /// <param name="method">From <see cref="HttpMethod"/>, should match ClickBank docs.</param>
    /// <param name="template">Templated route as per ClickBank docs.</param>
    /// <param name="handler">The actual function to run after receiving the response.</param>
    /// <returns>The <see cref="ClickBankBuilder"/> for chaining calls.</returns>
    public ClickBankBuilder OnResponse(HttpMethod method, string template, Func<IServiceProvider, HttpResponseMessage, CancellationToken, Task> handler)
    {
        _responseHandlers.Add(method, template, handler);
        return this;
    }

    internal HandlerRegistry RequestHandlers => _requestHandlers;
    internal HandlerRegistry ResponseHandlers => _responseHandlers;
}
