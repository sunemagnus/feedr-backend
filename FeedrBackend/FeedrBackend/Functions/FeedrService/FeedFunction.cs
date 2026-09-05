using FeedrBackend.Clients.Interface;
using FeedrBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

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
    public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post",
        Route = "postFeed")] HttpRequestData req, FeedModel feed,
        FunctionContext executionContext)
    {

        feed = new FeedModel
        {
            Name = "FirstFeed",
            Description = "Lovely place to feed",
            Rating = 4,
            DateTime = DateTime.UtcNow,
            GeoCoordinate = new Coordinate(1, 2, 3)
        };

        var logger = executionContext.GetLogger("HttpTrigger1");
        logger.LogInformation("C# HTTP trigger function processed a request.");

        await _feedrServiceApiClient.PostFeed(feed);

        //var message = String.Format($"Rating: {feed.Rating}, Description: {feed.Description}");
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        return response;
    }
}