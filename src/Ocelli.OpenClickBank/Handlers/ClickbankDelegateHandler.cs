using Microsoft.Extensions.Logging;

namespace Ocelli.OpenClickBank.Handlers;

internal class ClickbankDelegateHandler(IServiceProvider sp, ClickbankBuilder builder) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var path = request.RequestUri?.AbsolutePath ?? "/";
        var method = request.Method.Method;

        // Request hook
        var reqHandler = builder.Requests.Resolve(method, path);
        if (reqHandler is not null)
        {
            try { await reqHandler(sp, request, cancellationToken).ConfigureAwait(false); }
            catch (Exception ex)
            {
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
        var resHandler = builder.Responses.Resolve(method, path);
        if (resHandler is not null)
        {
            try { await resHandler(sp, response, cancellationToken).ConfigureAwait(false); }
            catch (Exception ex)
            {
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
