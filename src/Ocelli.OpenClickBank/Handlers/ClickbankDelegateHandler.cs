
using Microsoft.Extensions.Logging;

namespace Ocelli.OpenClickBank.Handlers;
internal class ClickbankDelegateHandler(IServiceProvider sp, ClickbankBuilder builder) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

        try
        {
            var task = request.RequestUri?.AbsolutePath switch
            {
                "/orders2/list" when builder.ProcessOrderResponse is not null => builder.ProcessOrderResponse(sp, response, cancellationToken),

                _ => Task.CompletedTask,
            };

            await task.ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            var maybe = sp.GetService(typeof(ILoggerFactory));
            if (maybe != null && maybe is ILoggerFactory factory)
            {
                var logger = factory.CreateLogger(nameof(ClickbankDelegateHandler));
                logger.LogWarning(ex, "Clickbank response hook failed for {RequestUri}", request.RequestUri);
            }
        }

        return response;
    }
}
