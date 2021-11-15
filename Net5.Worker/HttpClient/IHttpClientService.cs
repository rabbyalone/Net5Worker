using System;

namespace Net5.Worker.Parser
{
    public interface IHttpClientService
    {
        public string GetHttpResponse(string url,string username, string password);
    }
}
