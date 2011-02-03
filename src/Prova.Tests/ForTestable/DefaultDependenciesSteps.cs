using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Prova.Tests.ForTestable
{
    [Binding]
    public class DefaultDependenciesSteps : Steps
    {
        private readonly TestableContext _context;

        public DefaultDependenciesSteps(TestableContext context)
        {
            _context = context;
        }

        [Given(@"I clear all the default dependencies for the (.*)")]
        public void ClearAllTheDefaultDependenciesFor(Type type)
        {
            Testable.InstancesOf(type).UseNoDefaults();
        }

        [When(@"I want all testables for the (.*) to use the (.*)")]
        public void AllTestablesToHaveDefaultDependency(Type testableType, Type defaultDependencyType)
        {
            Testable.InstancesOf(testableType).UseDefaultOf(defaultDependencyType);
        }

        [When(@"I want all testables for the (.*) to use a function that returns the (.*)")]
        public void AllTestablesToHaveDefaultDependencyFunction(Type testableType, Type defaultDependencyType)
        {
            Func<dynamic> blah = () => Activator.CreateInstance(defaultDependencyType);

            Testable.InstancesOf(testableType).UseDefaultOf(blah);
        }

        [When(@"I create two testables for the (.*)")]
        public void CreateTwoTestablesFor(Type type)
        {
            _context.Testable = new Testable(type);
            _context.OtherTestable = new Testable(type);
        }

        [When(@"I want to use both the testable instances")]
        public void UseBothTheTestableInstances()
        {
            _context.Instance = _context.Testable.Create();
            _context.SecondInstance = _context.OtherTestable.Create();
        }

        [Then(@"I should have two instances with different dependencies")]
        public void ShouldHaveTwoInstancesWithDifferentDependencies()
        {
            Assert.That(_context.Instance.Dependency, Is.Not.EqualTo(_context.SecondInstance.Dependency));
        }
    }
}