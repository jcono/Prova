using System;
using NUnit.Framework;
using Prova.Extensions;
using TechTalk.SpecFlow;

namespace Prova.Tests.ForTestable
{
    [Binding]
    public class TestableSteps
    {
        private readonly TestableContext _context;

        public TestableSteps(TestableContext context)
        {
            _context = context;
        }

        [Given(@"I create a testable for a (.*)")]
        [When(@"I create a testable for a (.*)")]
        public void CreateTestableWith(Type type)
        {
            Action action = () =>
            {
                Testable.InstancesOf(type).UseNoDefaults();
                _context.Testable = new Testable(type);
                _context.Instance = _context.Testable.Create();
            };
            _context.Exception = action.GetException();
        }

        [When(@"I tell the testable to use and (.*) as a dependency")]
        public void TellTheTestableToUseDependency(dynamic dependency)
        {
            Action action = () =>
            {
                _context.ExpectedDependency = dependency;
                _context.Testable.With(dependency);
            };
            _context.Exception = action.GetException();
        }

        [When(@"I want to use the testable instance")]
        public void UseTheTestableObject()
        {
            _context.Instance = _context.Testable.Create();
        }

        [Then(@"I should have an instance with that has a (.*)")]
        public void ShouldHaveTestableInstanceWith(Type type)
        {
            Assert.That(_context.Instance, Is.InstanceOf(type));
        }

        [Then(@"I should have seen an exception with a (.*)")]
        public void ShouldHaveSeenAnExceptionWith(Type type)
        {
            Assert.That(_context.Exception, Is.InstanceOf(type));
        }

        [Then(@"I should have an instance that uses that dependency")]
        public void ShouldHaveAnInstanceThatUsesThatExplicitDependency()
        {
            Assert.That(_context.Instance.Dependency, Is.EqualTo(_context.ExpectedDependency));
        }
    }
}