using RestSharp;


namespace APITesting.Core
{
    public class BaseClient
    {
        private readonly RestClient _client;

        public BaseClient(string baseUrl) 
        { 
        _client = new RestClient(baseUrl);
        }

        public RestResponse ExecuteRequest(string resource, Method method)
        {
            var request = new RestRequest(resource, method);

            return _client.Execute(request);
        }

    }
}
