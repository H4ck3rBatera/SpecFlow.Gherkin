using TechTalk.SpecFlow;

namespace SpecFlow.Gherkin.IntegrationTest.Hooks
{
    [Binding]
    public sealed class HooksConfig
    {
        [StepArgumentTransformation(@"<null>")]
        public string ToNull()
        {
            return null;
        }
    }
}