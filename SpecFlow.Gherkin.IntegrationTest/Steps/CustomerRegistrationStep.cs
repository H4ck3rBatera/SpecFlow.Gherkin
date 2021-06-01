using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using SpecFlow.Gherkin.Api;
using SpecFlow.Gherkin.Domain.Models;
using SpecFlow.Gherkin.IntegrationTest.Support.Extensions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using SpecFlow.Gherkin.Api.ViewModels;
using TechTalk.SpecFlow;

namespace SpecFlow.Gherkin.IntegrationTest.Steps
{
    [Binding]
    public sealed class CustomerRegistrationStep
    {
        private readonly Customer _customer;
        private readonly HttpClient _client;
        private HttpResponseMessage _response;

        public CustomerRegistrationStep(WebApplicationFactory<Startup> webApplicationFactory)
        {
            _customer = new Customer();

            var factory = webApplicationFactory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureAppConfiguration((host, config) =>
                {
                    config.AddTestConfig(host.HostingEnvironment);
                });
            });

            _client = factory.CreateClient();
        }

        [Given(@"I have entered Name (.*) into the form")]
        public void GivenIHaveEnteredNameIntoTheForm(string name)
        {
            _customer.Name = name;
        }

        [Given(@"I have entered Last Name (.*) into the form")]
        public void GivenIHaveEnteredLastNameIntoTheForm(string lastName)
        {
            _customer.LastName = lastName;
        }

        [When(@"I press add")]
        public async Task WhenIPressAdd()
        {
            var json = Utf8Json.JsonSerializer.PrettyPrint(Utf8Json.JsonSerializer.Serialize(_customer));

            _response = await _client
                .PostAsync("/api/CustomerRegistration",
                    new StringContent(json, Encoding.UTF8
                        , "application/json"))
                .ConfigureAwait(false);
        }

        [Then(@"the result should be the Full Name registered")]
        public async Task ThenTheResultShouldBeTheFullNameRegistered()
        {
            _response.EnsureSuccessStatusCode();

            var body = await _response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var actual = JsonConvert.DeserializeObject<int>(body);

            actual.Should().NotBe(0);
        }

        [Then(@"the result should be the Full Name unregistered")]
        public void ThenTheResultShouldBeTheFullNameUnregistered()
        {
            _response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

    }
}