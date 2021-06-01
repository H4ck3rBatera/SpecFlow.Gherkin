using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpecFlow.Gherkin.Domain.Models;
using SpecFlow.Gherkin.Domain.Services.Interfaces;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using SpecFlow.Gherkin.Api.ViewModels;

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
        public async Task<IActionResult> PostAsync(CustomerViewModel customerViewModel, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Entering {nameof(PostAsync)}");

            try
            {
                var customer = new Customer { Name = customerViewModel.Name, LastName = customerViewModel.LastName };

                var id = await _customerRegistrationService.RegisterAsync(customer, cancellationToken).ConfigureAwait(false);

                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}