using NUnit.Framework;
using Prova.Tests.ForTestable.Types;
using Rhino.Mocks;
using TechTalk.SpecFlow;

namespace Prova.Tests.ForTestable
{
    [Binding]
    public class MultipleDependenciesSteps
    {
        private readonly TestableContext _context;

        public MultipleDependenciesSteps(TestableContext context)
        {
            _context = context;
        }

        [Given(@"I specify that testable instances use a default dependency")]
        public void GivenISpecifyThatInstancesUseDefaultDependency()
        {
            ScenarioContext.Current.Pending();

//            Testable.InstancesOf(typeof(HasMultipleDependencies)).UsesDefault(() => new DefaultDependency());
        }

        [Given(@"I use an explicit dependency")]
        public void GivenIUseAnExplicitDependency()
        {
            _context.FirstTestable.With(new ExplicitDependency());
        }

        [Then(@"I should have a default dependency")]
        public void ShouldHaveADefaultDependency()
        {
            Assert.That(_context.FirstInstance.ShouldBeDefault, Is.InstanceOf(typeof(DefaultDependency)));
        }

        [Then(@"I should have an explicit dependency")]
        public void ShouldHaveAnExplicitDependency()
        {
            Assert.That(_context.FirstInstance.ShouldBeExplicit, Is.InstanceOf(typeof(ExplicitDependency)));
        }

        [Then(@"I should have a canned dependency")]
        public void ShouldHaveACannedDependency()
        {
            Assert.That(_context.FirstInstance.ShouldBeImplicit, Is.InstanceOf(typeof(CannedImplicitDependency)));
        }

        [Then(@"I should have a mocked dependency")]
        public void ShouldHaveAMockedDependency()
        {
            Assert.That(_context.FirstInstance.ShouldBeMocked, Is.InstanceOf(MockRepository.GenerateStub<IMockedDependency>().GetType()));
        }
    }
}