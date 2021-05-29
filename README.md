# SpecFlow.Gherkin

### Visual Studio Extensions:
```
	SpecFlow for Visual Studio 2019
```

### CustomerRegistration.feature
```
Feature: Manage Basic Customer Registration

@CustomerRegistration
Scenario: Register Name and Last Name
	Given I have entered Name "Jessé" into the form
	And I have entered Last Name "Toledo" into the form
	When I press add
	Then the result should be the Full Name registered
```

### CustomerRegistrationStep.cs
```csharp
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

        [Then(@"the result should be the Full Name registered")]
        public async Task ThenTheResultShouldBeTheFullNameRegistered()
        {
            _response.EnsureSuccessStatusCode();

            var body = await _response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var actual = JsonConvert.DeserializeObject<int>(body);

            actual.Should().NotBe(0);
        }
    }
```

### ConfigurationExtensions.cs
```csharp
public static class ConfigurationExtensions
    {
        public static IConfigurationBuilder AddTestConfig(this IConfigurationBuilder configurationBuilder, IWebHostEnvironment webHostEnvironment)
        {
            configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                                .AddJsonFile($"appsettings.{webHostEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: false);

            return configurationBuilder;
        }
    }
```

### docker-compose.yml
```yaml
version: '3.4'

services:
    sql_server:
        image: mcr.microsoft.com/mssql/server:latest
        ports:
            - "1433:1433"
        environment:
            SA_PASSWORD: 'P@ssword'
            ACCEPT_EULA: 'Y'
```

### PowerShell
```shell
docker-compose up --build
```

