namespace Ocelli.OpenClickBank;

internal partial class Orders2Client
{
    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
    {
        request.Options.Set(new HttpRequestOptionsKey<string>("cb.url"), url);
    }
}
