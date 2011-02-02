using System;
using NUnit.Framework;
using Prova.Extensions;
using Prova.Tests.ForTestable.Types;
using TechTalk.SpecFlow;

namespace Prova.Tests.ForTestable
{
    [Binding]
    public class ExplicitDependenciesSteps
    {
        private readonly TestableContext _context;

        public ExplicitDependenciesSteps(TestableContext context)
        {
            _context = context;
        }

        [When(@"I tell the testable object to use an explicit dependency")]
        public void TellTheTestableObjectToUseAnExplicitDependency()
        {
            _context.ExplicitDependency = new StubDependency();
            _context.FirstTestable.With(_context.ExplicitDependency);
        }

        [When(@"I tell the object to use a dependency it does not have")]
        public void TellTheObjectToUseDependencyItDoesNotHave()
        {
            Action action = () => _context.FirstTestable.With(new UnusedDependency());
            _context.Exception = action.GetException();
        }

        [Then(@"I should have an instance that uses that explicit dependency")]
        public void HaveAnInstanceThatUsesThatExplicitDependency()
        {
            Assert.That(_context.FirstInstance.Dependency, Is.EqualTo(_context.ExplicitDependency));
        }
    }
}