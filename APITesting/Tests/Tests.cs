using NUnit.Framework; 
using APITesting.Business;
using RestSharp;
using APITesting.Core.Utilities;
using FluentAssertions.Execution;
using FluentAssertions;
using APITesting.Business.User.UserBuilder;


namespace APITesting.Test.Tests
{
    internal class Tests
    {
        [TestFixture]
        [Category("API")]
        [Parallelizable(ParallelScope.Fixtures)]
        public class UserServiceTests : TestBase
        {


            [Test]
            public void GetUsers_ValidateResponseStructure()
            {
                Log.LogInfo("Starting test: GetUsers_ValidateResponseStructure");

                Log.LogDebug("Calling GetUser API...");
                var (users, response) = userService.GetUsers();

                Log.LogDebug($"Received response with status code {(int)response.StatusCode} - {response.StatusDescription}"); //This logging can be placed in the GetUsers() method


                Assert.AreEqual(200, (int)response.StatusCode, "Expected 200 OK response.");
                Assert.IsNull(response.ErrorException, $"Error retrieving response {response.ErrorMessage}");

                Console.WriteLine($"{(int)response.StatusCode} - {response.StatusDescription}");

                if (users.Count == 0) 
                {
                    Log.LogWarn("No users to validate");
                }
                else 
                { 

                foreach (var user in users) 
                {
                    Log.LogDebug($"Validating user: {user.Id}");

                        using (new AssertionScope())
                        {
                            user.Id.Should().NotBe(null, "User should have a valid 'id'."); //is this acceptable?
                            user.Name.Should().NotBeNull("User should have a 'name'.");
                            user.Username.Should().NotBeNull("User should have a 'username'.");
                            user.Email.Should().NotBeNull("User should have an 'email'.");
                            user.Address.Should().NotBeNull("User should have an 'address'.");
                            user.Phone.Should().NotBeNull("User should have a 'phone'.");
                            user.Website.Should().NotBeNull("User should have a 'website'.");
                            user.Company.Should().NotBeNull("User should have a 'company'.");
                          
                        }
                        Console.WriteLine($"{user.Id}, {user.Name}, {user.Username}, {user.Email}, {user.Address}, {user.Phone}, {user.Website}, {user.Company}");
                    }
            }

                Log.LogInfo($"Test GetUsers_ValidateResponseStructure completed");
            }


            [TestCase("Content-Type", "application/json; charset=utf-8")]
            public void GetUsers_ValidateResponseHeader(string headerName, string headerValue)

            {
                Log.LogInfo("Starting test: GetUsers_ValidateResponseHeader");
                
                Log.LogDebug("Calling GetUsers API...");
                var (users, response) = userService.GetUsers();

                Log.LogDebug($"Received response with status code {(int)response.StatusCode} - {response.StatusDescription}");
                Assert.AreEqual(200, (int)response.StatusCode, "Expected 200 OK response.");
                Assert.IsNull(response.ErrorException, $"Error retrieving response {response.ErrorMessage}");


                Assert.IsNotNull(response.ContentHeaders, "Response headers don't exist in the obtained response");


                Log.LogDebug($"Validating that {headerName} header exists in the response");
                var searchedHeader = response.ContentHeaders.FirstOrDefault(h => h.Name.Equals($"{headerName}", StringComparison.OrdinalIgnoreCase));
                Assert.IsNotNull(searchedHeader, $"{headerName} header is missing in the response");

                string searchedHeaderValue = searchedHeader.Value.ToString();

                Log.LogDebug($"Validating header's value: {headerName} = {headerValue}");
                Assert.AreEqual($"{headerValue}", searchedHeaderValue, $"Expected header value should be {headerValue}");

                Log.LogInfo($"Test GetUsers_ValidateResponseHeader completed");
            }

            [Test]
             public void GetUsers_ValidateResponseContent()
                {

                Log.LogInfo("Starting test: GetUsers_ValidateResponseContent");

                Log.LogDebug("Calling GetUsers API...");
                var (users, response) = userService.GetUsers();

                Log.LogDebug($"Received response with status code {(int)response.StatusCode} - {response.StatusDescription}");
                Assert.AreEqual(200, (int)response.StatusCode, "Expected 200 OK response.");
                Assert.IsNull(response.ErrorException, $"Error retrieving response {response.ErrorMessage}");

                Log.LogDebug($"Validating number of users returned {users.Count}");
                 Assert.AreEqual(10, users.Count, "Expected 10 users from the API.");

                 foreach (var user in users)
                 {
                    Log.LogDebug($"Validating user {user.Name} {user.Username}");
                    Assert.IsNotEmpty(user.Name, "name should not be empty");
                    Assert.IsNotEmpty(user.Username, "username should not be empty");
                    Log.LogDebug($"Validating user's company name for userID {user.Id} - {user.Company.Name}");
                    Assert.IsNotNull(user.Company, "Company should not be null");
                    Assert.IsNotEmpty(user.Company.Name, "Company name should not be empty");
                 }


                Log.LogDebug($"Validating uniqness of users IDs");
                var userIds = users.Select(u => u.Id).ToList();
                var distinctUserIds = userIds.Distinct().ToList();
                Assert.AreEqual(userIds.Count, distinctUserIds.Count, "User ids should be unique");

                Log.LogInfo("Test completed: GetUsers_ValidateResponseContent");
            }

            [Test]
             public void GetInvalidEndpoint()
             {
                Log.LogInfo("Starting test: GetInvalidEndpoint");//reduce number of logs

                Log.LogDebug("Calling GetUsers API with invalid endpoint...");
                var response = baseClient.Get("invalidendpoint"); //do the same for post

                Log.LogDebug($"Received response with status code {(int)response.StatusCode} - {response.StatusDescription}");
                bool isInvalid = (int)response.StatusCode == 404 && response.StatusDescription == "Not Found";
                Assert.IsNull(response.ErrorException, $"Error retrieving response {response.ErrorMessage}");


                Log.LogDebug($"Validating Status code and Status description for invalid endpoint");
                Assert.IsTrue(isInvalid, $"Expected 404 code and description 'Not found', but received {(int)response.StatusCode} and {response.StatusDescription}");
                
                Log.LogInfo("Test completed: GetInvalidEndpoint");
            }

            [Test]
            public void CreateUser() 
            {
                Log.LogInfo("Starting test: CreateUser");

                var newUser = new User
                {
                    Name = "Gosia",
                    Username = "GosQA"
                };

                Log.LogDebug($"Creating user with Name: {newUser.Name} and Username: {newUser.Username}");
                var response = userService.CreateUser(newUser);

                Log.LogDebug($"Received response with status code {(int)response.StatusCode} - {response.StatusDescription}");
                Assert.IsNotEmpty(response.Content);
                Assert.IsNotNull(newUser.Id);


                bool userCreated = (int)response.StatusCode == 201 && response.StatusDescription == "Created";
                Assert.IsTrue(userCreated, $"Expected 202 status code and description 'Created', but received {(int)response.StatusCode} and {response.StatusDescription}");
                Assert.IsNull(response.ErrorException, $"Error retrieving response {response.ErrorMessage}");

                Log.LogDebug($"New user was successfully created with the ID: {newUser.Id}");
                
                Log.LogInfo("Test completed: CreateUser");
            }        
        }
    } 
}
