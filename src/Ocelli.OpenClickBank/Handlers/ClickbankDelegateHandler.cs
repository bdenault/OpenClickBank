using Microsoft.Extensions.Logging;

namespace Ocelli.OpenClickBank.Handlers;

/// <summary>
/// Handles HTTP request and response delegation for ClickBank operations, allowing for custom request and response
/// processing.
/// </summary>
/// <remarks>This handler enables the execution of custom logic before and after the HTTP request is processed. It
/// utilizes request and response hooks that can be resolved from the <see cref="ClickBankBuilder"/> based on the
/// HTTP method and request path. If a hook fails, a warning is logged using the provided <see cref="ILoggerFactory"/>.
/// </remarks>
internal class ClickBankDelegateHandler(IServiceProvider sp, ClickBankBuilder builder) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var path = request.RequestUri?.AbsolutePath ?? "/";
        var method = request.Method.Method;

        // Request hook
        var reqHandler = builder.RequestHandlers.Resolve(method, path);
        if (reqHandler is not null)
        {
            // Try the handler
            try { await reqHandler(sp, request, cancellationToken).ConfigureAwait(false); }
            catch (Exception ex)
            {
                // Handler failed, log warning if logger present
                var maybe = sp.GetService(typeof(ILoggerFactory));
                if (maybe is ILoggerFactory factory)
                {
                    var logger = factory.CreateLogger("Ocelli.OpenClickBank.RequestHandler");
                    logger.LogWarning(ex, "Request hook failed for {Method} {Path}", method, path);
                }
            }
        }

        // Make the call
        var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

        // Response hook
        var resHandler = builder.ResponseHandlers.Resolve(method, path);
        if (resHandler is not null)
        {
            // Try the handler
            try { await resHandler(sp, response, cancellationToken).ConfigureAwait(false); }
            catch (Exception ex)
            {
                // Handler failed, log warning if logger present
                var maybe = sp.GetService(typeof(ILoggerFactory));
                if (maybe is ILoggerFactory factory)
                {
                    var logger = factory.CreateLogger("Ocelli.OpenClickBank.ResponseHandler");
                    logger.LogWarning(ex, "Response hook failed for {Method} {Path}", method, path);
                }
            }
        }

        return response;
    }
}
