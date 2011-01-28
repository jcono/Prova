using Prova.Tests.ForTestable.Types;
using TechTalk.SpecFlow;

namespace Prova.Tests.ForTestable
{
    [Binding]
    public class MultipleDependenciesStepDefinitions
    {
        [Given(@"I specify a default dependency to use")]
        public void GivenISpecifyADefaultDependencyToUse()
        {
            Testable.InstanceOf(typeof(HasMultipleDependencies)).UsesDefault(() => new DefaultDependency());
        }

        [Given(@"I use a dependency ExplicitDependency")]
        public void GivenIUseADependencyExplicitDependency()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I use the testable object")]
        public void WhenIUseTheTestableObject()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should have a default dependency with the correct type")]
        public void ThenIShouldHaveADefaultDependencyWithTheCorrectType()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should have an explicit dependency")]
        public void ThenIShouldHaveAnExplicitDependency()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should have a canned dependency")]
        public void ThenIShouldHaveACannedDependency()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should have a mocked dependency")]
        public void ThenIShouldHaveAMockedDependency()
        {
            ScenarioContext.Current.Pending();
        }
    }
}