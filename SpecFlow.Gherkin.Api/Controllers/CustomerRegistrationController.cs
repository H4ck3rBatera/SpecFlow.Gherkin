using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpecFlow.Gherkin.Domain.Models;
using SpecFlow.Gherkin.Domain.Services.Interfaces;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SpecFlow.Gherkin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRegistrationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ICustomerRegistrationService _customerRegistrationService;

        public CustomerRegistrationController(
            ILogger<CustomerRegistrationController> logger,
            ICustomerRegistrationService customerRegistrationService)
        {
            _logger = logger;
            _customerRegistrationService = customerRegistrationService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Customer customer, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Entering {nameof(PostAsync)}");

            try
            {
                var id = await _customerRegistrationService.RegisterAsync(customer, cancellationToken).ConfigureAwait(false);

                return Ok(id);
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}