using FeedrBackend.Clients.Interface;
using FeedrBackend.Models;
using System.Net.Http.Json;

public class FeedrServiceApiClient : IFeedrServiceApiClient
{
    private readonly HttpClient _httpClient;

    public FeedrServiceApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<HttpResponseMessage> PostFeed(FeedModel feed)
    {
        ArgumentNullException.ThrowIfNull(feed);
        var response = await _httpClient.PostAsJsonAsync("api/postFeed", feed).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        return response;
    }
}