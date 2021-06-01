using System.ComponentModel.DataAnnotations;

namespace SpecFlow.Gherkin.Api.ViewModels
{
    public class CustomerViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}