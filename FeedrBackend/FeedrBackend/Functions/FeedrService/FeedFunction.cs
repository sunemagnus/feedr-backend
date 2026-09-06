using FeedrBackend.Clients.Interface;
using FeedrBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json.Nodes;

namespace FeedrBackend.Functions.FeedrService;

public class FeedFunction
{
    private readonly ILogger<FeedFunction> _logger;
    private readonly IHttpClientFactory httpClientFactory;
    public  IFeedrServiceApiClient _feedrServiceApiClient;

    public FeedFunction(ILogger<FeedFunction> logger, IFeedrServiceApiClient feedrServiceApiClient)
    {
        _logger = logger;
        _feedrServiceApiClient = feedrServiceApiClient;
    }



    [Function("PostFeed")]
    public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Function, "post",
        Route = "postFeed")] HttpRequestData req, FunctionContext executionContext)
    {
        var feed = await req.ReadFromJsonAsync<FeedModel>();

        var logger = executionContext.GetLogger("HttpTrigger1");
        logger.LogInformation("C# HTTP trigger function processed a request.");

        var res = await _feedrServiceApiClient.PostFeed(feed);

        if (res.IsSuccessStatusCode)
        {
            logger.LogInformation("Success received from feedr-service.");
        }

        //var message = String.Format($"Rating: {feed.Rating}, Description: {feed.Description}");
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        return response;
    }
}