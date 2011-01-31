using System;
using NUnit.Framework;
using Prova.Tests.ForTestable.Types;
using TechTalk.SpecFlow;

namespace Prova.Tests.ForTestable
{
    [Binding]
    [StepScope(Feature = "Can provide different ways of supplying a dependency to a class with a single dependency")]
    public class SingleDependencySteps
    {
        private Testable _testable;
        private Testable _secondTestable;
        private HasSingleDependency _instance;
        private HasSingleDependency _secondInstance;
        private IDependency _explicitDependency;

        [Given(@"I want to use a default dependency")]
        public void WantToUseADefaultDependency()
        {
            Testable.InstancesOf(typeof(HasSingleDependency)).UsesDefault(() => new Dependency());
        }

        [Given(@"I have a testable with a (.*)")]
        public void HaveTestable(Type type)
        {
            _testable = new Testable(type);
        }

        [Given(@"I have another testable with a (.*)")]
        public void HaveAnotherTestable(Type type)
        {
            _secondTestable = new Testable(type);
        }

        [When(@"I use the testable object")]
        public void UseTheTestableObject()
        {
            _instance = _testable.Create();
        }

        [When(@"I use the other testable object")]
        public void UseTheOtherTestableObject()
        {
            _secondInstance = _secondTestable.Create();            
        }

        [When(@"I tell the testable object to use an explicit dependency")]
        public void TellTheTestableObjectToUseAnExplicitDependency()
        {
            _explicitDependency = new StubDependency();
            _testable.With(_explicitDependency);
        }

        [Then(@"I should have a dependency with a (.*)")]
        public void ShouldHaveDependencyOf(Type expectedType)
        {
            Assert.That(_instance.Dependency, Is.InstanceOf(expectedType));
        }

        [Then(@"I should have an instance that uses that explicit dependency")]
        public void ShouldHaveAnInstanceThatUsesThatExplicitDependency()
        {
            Assert.That(_instance.Dependency, Is.EqualTo(_explicitDependency));
        }

        [Then(@"The two instances should have different dependencies")]
        public void TheTwoInstancesShouldHaveDifferentDependencies()
        {
            Assert.That(_instance.Dependency, Is.Not.EqualTo(_secondInstance.Dependency));
        }

    }
}