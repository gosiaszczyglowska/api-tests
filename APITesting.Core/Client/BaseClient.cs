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

        public RestResponse Get(string resource) //the same for post
        {
            return ExecuteRequest(resource, Method.Get);
        }
        public RestResponse ExecuteRequest(string resource, Method method)//TODO: you can put the logging here and every request will be logged -it should be private
        {
            var request = new RestRequest(resource, method);

            return _client.Execute(request);
        }

        //TODO: learn about interfaces


        //2 more methods - Get request and Post request, execute request , make it private
    }
}
