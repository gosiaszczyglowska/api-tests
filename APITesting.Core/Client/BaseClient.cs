using APITesting.Core.Utilities;
using RestSharp;


namespace APITesting.Core.Client
{
    public class BaseClient
    {
        private readonly RestClient _client;

        public BaseClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public RestResponse Get(string resource) 
        {
            return ExecuteRequest(resource, Method.Get);
        }

        public RestResponse Post(string resource) 
        {
            return ExecuteRequest(resource, Method.Post);
        }

        private RestResponse ExecuteRequest(string resource, Method method)
        {
            var request = new RestRequest(resource, method);
            var response = _client.Execute(request);
            Log.LogDebug($"Received response with status code {(int)response.StatusCode} - {response.StatusDescription}");

            return response;
        }

        //TODO: learn about interfaces


        //2 more methods - Get request and Post request, execute request , make it private
    }
}
