﻿using APITesting.Core;
using APITesting.Core.Client;
using Newtonsoft.Json;
using RestSharp;

namespace APITesting.Business.User
{
    public class UserService
    {
        private readonly BaseClient _baseClient;

        public UserService(BaseClient baseClient)
        {
            _baseClient = baseClient;
        }

        public (List<User>, RestResponse) GetUsers() 
        {

            var response = _baseClient.Get("users");

            if (response.Content != null)
            {
                var users = JsonConvert.DeserializeObject<List<User>>(response.Content); //TODO: can be moved to a method List<T> DeserializeObject(string responseContent)
                                                                                         //(static JSON helper method / parse object
                return (users ?? new List<User>(), response);
            }
            else
            {
                throw new Exception("Response content is null.");
            }
        }

        public RestResponse CreateUser(User newUser) 
        {
            var response = _baseClient.ExecuteRequest("users", Method.Post);
            return response;
        }
    }
}
