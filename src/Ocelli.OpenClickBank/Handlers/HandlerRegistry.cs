using System.Text;
using System.Text.RegularExpressions;

namespace Ocelli.OpenClickBank.Handlers;

internal sealed class HandlerRegistry
{
    private readonly Dictionary<string, List<Entry>> _byMethod = new(StringComparer.OrdinalIgnoreCase);

    public void Add<TMsg>(HttpMethod method, string template, Func<IServiceProvider, TMsg, CancellationToken, Task> handler)
    {
        var key = method.Method;
        if (!_byMethod.TryGetValue(key, out var list))
        {
            list = [];
            _byMethod[key] = list;
        }

        var entry = Entry.Create(template, (sp, msg, ct) => handler(sp, (TMsg)msg, ct));
        list.Add(entry);

        // Keep most specific first (more literal chars -> higher score)
        list.Sort(static (a, b) => b.Specificity.CompareTo(a.Specificity));
    }

    public Func<IServiceProvider, object, CancellationToken, Task>? Resolve(string method, string path)
    {
        if (!_byMethod.TryGetValue(method, out var list)) return null;

        foreach (var e in list)
        {
            if (e.Pattern.IsMatch(path))
                return e.Handler;
        }
        return null;
    }

    internal sealed class Entry
    {
        public required Regex Pattern { get; init; }
        public required Func<IServiceProvider, object, CancellationToken, Task> Handler { get; init; }
        public required int Specificity { get; init; } // higher = more literal

        public static Entry Create(string template, Func<IServiceProvider, object, CancellationToken, Task> handler)
        {
            // Convert "/orders2/{id}/items/{itemId}" -> ^/orders2/[^/]+/items/[^/]+$
            // Treat "{*rest}" (catch-all) as ".*"
            var sb = new StringBuilder("^");
            var specificity = 0;

            foreach (var segment in template.Split('/', StringSplitOptions.RemoveEmptyEntries))
            {
                sb.Append('/');

                if (segment.StartsWith("{*") && segment.EndsWith('}'))
                {
                    sb.Append(".*"); // Catch-all
                }
                else if (segment.StartsWith('{') && segment.EndsWith('}'))
                {
                    sb.Append("[^/]+"); // Single segment param
                }
                else
                {
                    // Literal segment
                    sb.Append(Regex.Escape(segment));
                    specificity += segment.Length;
                }
            }

            // Allow root "/"
            if (template == "/") sb.Append('/');

            sb.Append('$');

            var regex = new Regex(sb.ToString(),
                RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

            return new Entry
            {
                Pattern = regex,
                Handler = handler,
                Specificity = specificity,
            };
        }
    }
}