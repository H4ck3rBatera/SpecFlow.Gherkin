using Microsoft.AspNetCore.Mvc.Testing;
using SpecFlow.Gherkin.Api;
using SpecFlow.Gherkin.Domain.Models;
using SpecFlow.Gherkin.IntegrationTest.Support.Extensions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlow.Gherkin.IntegrationTest.Steps
{
    [Binding]
    public sealed class CustomerRegistrationStep
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly Customer _customer;
        private readonly HttpClient _client;
        private HttpResponseMessage _response;

        public CustomerRegistrationStep(ScenarioContext scenarioContext, WebApplicationFactory<Startup> factory)
        {
            _scenarioContext = scenarioContext;
            _customer = new Customer();

            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureAppConfiguration((host, config) =>
                {
                    config.AddTestConfig(host.HostingEnvironment);
                });
            });

            _client = _factory.CreateClient();
        }

        [Given(@"I have entered Name ""(.*)"" into the form")]
        public void GivenIHaveEnteredNameIntoTheForm(string name)
        {
            _customer.Name = name;
        }

        [Given(@"I have entered Last Name ""(.*)"" into the form")]
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

        [Then(@"the result should be the Full Name ""(.*)"" registered")]
        public void ThenTheResultShouldBeTheFullNameRegistered(string fullName)
        {
            ScenarioContext.Current.Pending();
        }

    }
}