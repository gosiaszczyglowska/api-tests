using APITesting.Core;
using APITesting.Core.Client;
using Newtonsoft.Json;
using RestSharp;
using APITesting.Core.Utilities;

namespace APITesting.Business.User
{
    public class UserService
    {
        private readonly BaseClient _baseClient;

        public UserService(BaseClient baseClient)
        {
            _baseClient = baseClient;
        }

        public (List<UserBuilder.User>, RestResponse) GetUsers()
        {

            {
                var response = _baseClient.Get("users");

                if (response.Content != null)
                {
                    var users = JsonHelper.DeserializeObject<List<UserBuilder.User>>(response.Content);
                    return (users, response);
                }
                else
                {
                    throw new Exception("Response content is null.");
                }
            }
        }

        public RestResponse CreateUser(UserBuilder.User newUser)
        {
            var response = _baseClient.Post("users");
            return response;
        }
    } }
