using Bogus;
using BugTracker.Application.Models.Identity;
using System.Net.Http.Json;
using FluentAssertions;
using System.Net;

namespace BugTracker.Api.IntegrationTests.AuthController
{
    public class RegisterAuthControllerTests : IClassFixture<BugTrackerApiFactory>
    {
        private readonly BugTrackerApiFactory _bugTrackerApiFactory;
        private readonly HttpClient _httpClient;
        private readonly Faker<RegisterRequest> _registerRequestGenerator = new Faker<RegisterRequest>()
            .RuleFor(r => r.Password, f => f.Internet.Password())
            .RuleFor(r => r.Email, f => f.Person.Email)
            .RuleFor(r => r.FirstName, f => f.Person.FirstName)
            .RuleFor(r => r.LastName, f => f.Person.LastName);
            
        public RegisterAuthControllerTests(BugTrackerApiFactory bugTrackerApiFactory)
        {
            _bugTrackerApiFactory = bugTrackerApiFactory;
            _httpClient = _bugTrackerApiFactory.CreateClient();
        }

        [Fact]
        public async Task Register_RegisterUser_WhenDataIsValid()
        {
            //Arrange
            var request = _registerRequestGenerator.Generate();

            //Act
            var response = await _httpClient.PostAsJsonAsync("api/auth/register", request);

            //Assert
            var registerResponse = await response.Content.ReadFromJsonAsync<RegisterResponse>();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            registerResponse?.UserId.Should().NotBeNullOrEmpty();
        }

    }
}
