namespace Ocelli.OpenClickBank.Extensions;

public static class ClickBankBuilderExtensions
{
    /// <summary>
    /// Registers a new request handler for the provided <paramref name="operation"/>.
    /// </summary>
    /// <param name="operation">Only created via static helpers.</param>
    /// <param name="handler">The actual function to run before sending the request.</param>
    /// <returns>The <see cref="ClickBankBuilder"/> for chaining calls.</returns>
    public static ClickBankBuilder OnRequest(this ClickBankBuilder builder, ClickBankOperation operation, Func<IServiceProvider, HttpRequestMessage, CancellationToken, Task> handler) => builder.OnRequest(operation.Method, operation.Template, handler);

    /// <summary>
    /// Registers a new response handler for the provided <paramref name="operation"/>.
    /// </summary>
    /// <param name="operation">Only created via static helpers.</param>
    /// <param name="handler">The actual function to run after receiving the response.</param>
    /// <returns>The <see cref="ClickBankBuilder"/> for chaining calls.</returns>
    public static ClickBankBuilder OnResponse(this ClickBankBuilder builder, ClickBankOperation operation, Func<IServiceProvider, HttpResponseMessage, CancellationToken, Task> handler) => builder.OnResponse(operation.Method, operation.Template, handler);
}
