using System;
using Prova.Tests.ForTestable.Types;
using TechTalk.SpecFlow;

namespace Prova.Tests.ForTestable
{
    [Binding]
    public class DefaultDependenciesSteps
    {
        private readonly TestableContext _context;

        public DefaultDependenciesSteps(TestableContext context)
        {
            _context = context;
        }

        [Given(@"I want to use a default dependency on all testable instances with (.*)")]
        public void WantToUseADefaultDependencyFor(Type type)
        {
            ScenarioContext.Current.Pending();

//            Testable.InstancesOf(type).UsesDefault(() => new Dependency());
        }

        [When(@"I want to use a different default dependency on all testable instances with (.*)")]
        public void WantToUseADifferentDefaultDependencyFor(Type type)
        {
            ScenarioContext.Current.Pending();

//            Testable.InstancesOf(type).UsesDefault(() => new DifferentDependency());
        }

        [Then(@"I should have an instance that uses a different dependency")]
        public void ThenIShouldHaveAnInstanceThatUsesADifferentDependency()
        {
            ScenarioContext.Current.Pending();
        }

    }
}