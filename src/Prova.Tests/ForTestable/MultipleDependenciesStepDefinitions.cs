using System;
using NUnit.Framework;
using Prova.Tests.ForTestable.Types;
using Rhino.Mocks;
using TechTalk.SpecFlow;

namespace Prova.Tests.ForTestable
{
    [Binding]
    [StepScope(Tag = "Multiple_Dependencies")]
    public class MultipleDependenciesStepDefinitions
    {
        private Testable _testable;
        private HasMultipleDependencies _instance;

        [Given(@"I specify that testable instances use a default dependency")]
        public void GivenISpecifyThatInstancesUseDefaultDependency()
        {
            Testable.InstanceOf(typeof(HasMultipleDependencies)).UsesDefault(() => new DefaultDependency());
        }

        [Given(@"I have a testable (.*)")]
        public void GivenIHaveATestable(Type type)
        {
            _testable = new Testable(type);
        }

        [Given(@"I use an explicit dependency")]
        public void GivenIUseAnExplicitDependency()
        {
            _testable.With(new ExplicitDependency());
        }

        [When(@"I use the testable object")]
        public void WhenIUseTheTestableObject()
        {
            _instance = _testable.Create();
        }

        [Then(@"I should have a default dependency")]
        public void ThenIShouldHaveADefaultDependency()
        {
            Assert.That(_instance.ShouldBeDefault, Is.InstanceOf(typeof(DefaultDependency)));
        }

        [Then(@"I should have an explicit dependency")]
        public void ThenIShouldHaveAnExplicitDependency()
        {
            Assert.That(_instance.ShouldBeExplicit, Is.InstanceOf(typeof(ExplicitDependency)));
        }

        [Then(@"I should have a canned dependency")]
        public void ThenIShouldHaveACannedDependency()
        {
            Assert.That(_instance.ShouldBeImplicit, Is.InstanceOf(typeof(CannedImplicityDependency)));
        }

        [Then(@"I should have a mocked dependency")]
        public void ThenIShouldHaveAMockedDependency()
        {
            Assert.That(_instance.ShouldBeMocked, Is.InstanceOf(MockRepository.GenerateStub<IMockedDependency>().GetType()));
        }
    }
}