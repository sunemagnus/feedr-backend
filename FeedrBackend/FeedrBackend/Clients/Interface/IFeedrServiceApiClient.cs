using FeedrBackend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedrBackend.Clients.Interface
{
    public interface IFeedrServiceApiClient
    {
        public Task<HttpResponseMessage> PostFeed(FeedModel feed);
    }
}
