using System.Text;
using System.Text.RegularExpressions;

namespace Ocelli.OpenClickBank.Handlers;

/// <summary>
/// Abstracts the storage of handlers and the decision of which handler to use.
/// </summary>
internal sealed class HandlerRegistry
{
    private readonly Dictionary<string, List<Entry>> _byMethod = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Adds a new handler to <see langword="this"/>.
    /// </summary>
    /// <typeparam name="TMsg">Either <see cref="HttpRequestMessage"/> or <see cref="HttpResponseMessage"/> in practice</typeparam>
    /// <param name="method">Comes from <see cref="HttpMethod"/>.</param>
    /// <param name="template">The templated route or path of the operation.</param>
    /// <param name="handler">The actual function to run.</param>
    public void Add<TMsg>(HttpMethod method, string template, Func<IServiceProvider, TMsg, CancellationToken, Task> handler)
    {
        // Initialize value if not present
        var key = method.Method;
        if (!_byMethod.TryGetValue(key, out var list))
        {
            list = [];
            _byMethod[key] = list;
        }

        // Create and save a new entry (with slight modification to the message parameter)
        var entry = Entry.Create(template, (sp, msg, ct) => handler(sp, (TMsg)msg, ct));
        list.Add(entry);

        // Keep most specific first (more literal chars -> higher score)
        list.Sort(static (a, b) => b.Specificity.CompareTo(a.Specificity));
    }

    /// <summary>
    /// Given a <paramref name="method"/> and actual <paramref name="path"/>, attempt to retrieve the most specific handler.
    /// </summary>
    /// <param name="method">The <see cref="HttpMethod"/> to search against.</param>
    /// <param name="path">The actual route from the HTTP call</param>
    /// <returns>The matching handler if registered, otherwise <see langword="null"/></returns>
    public Func<IServiceProvider, object, CancellationToken, Task>? Resolve(string method, string path)
    {
        // If no handlers for the provided method/HTTP verb, no possibility of handlers being registered
        if (!_byMethod.TryGetValue(method, out var list)) return null;

        // Go through each entry
        foreach (var e in list)
        {
            // Take the first match, this will be the most specific
            if (e.Pattern.IsMatch(path))
                return e.Handler;
        }

        // Default return value
        return null;
    }

    /// <summary>
    /// Model to house a handler and when to use it.
    /// </summary>
    internal sealed class Entry
    {
        public required Regex Pattern { get; init; }
        public required Func<IServiceProvider, object, CancellationToken, Task> Handler { get; init; }
        public required int Specificity { get; init; } // higher = more literal

        /// <summary>
        /// Builds a new <see cref="Entry"/> using the provided <paramref name="template"/>.
        /// </summary>
        /// <returns>The new <see cref="Entry"/></returns>
        public static Entry Create(string template, Func<IServiceProvider, object, CancellationToken, Task> handler)
        {
            // Convert "/orders2/{id}/items/{itemId}" -> ^/orders2/[^/]+/items/[^/]+$
            // Treat "{*rest}" (catch-all) as ".*"
            var sb = new StringBuilder("^");
            var specificity = 0;

            // Go through each segment in the route
            foreach (var segment in template.Split('/', StringSplitOptions.RemoveEmptyEntries))
            {
                sb.Append('/');

                // Catch-all case
                if (segment.StartsWith("{*") && segment.EndsWith('}'))
                {
                    sb.Append(".*");
                }
                // This segment is a route parameter (like {receipt})
                else if (segment.StartsWith('{') && segment.EndsWith('}'))
                {
                    sb.Append("[^/]+");
                }
                // This segment is a string literal (like `orders2`)
                else
                {
                    sb.Append(Regex.Escape(segment));

                    // Increase specificity by the length of this literal
                    specificity += segment.Length;
                }
            }

            // Allow root "/"
            if (template == "/") sb.Append('/');

            // Close out the regex string
            sb.Append('$');

            // Build the regex dynamically, compiling now and ignoring case
            var regex = new Regex(sb.ToString(),
                RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

            // Build the entry and return
            return new Entry
            {
                Pattern = regex,
                Handler = handler,
                Specificity = specificity,
            };
        }
    }
}