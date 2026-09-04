using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;

namespace feedr_backend;

public class Function1
{
    private readonly ILogger<Function1> _logger;
    private readonly HttpClient _httpClient = new HttpClient();

    public Function1(ILogger<Function1> logger)
    {
        _logger = logger;
    }

    [Function("PostFeed")]
    public async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        var feedrService = Environment.GetEnvironmentVariable("FeedrService_Url");

        var response = await _httpClient.GetAsync(feedrService);
        var body = await response.Content.ReadAsStringAsync();

        return new ContentResult
        {
            Content = body,
            ContentType = "application/json",
            StatusCode = 200
        };
    }
}