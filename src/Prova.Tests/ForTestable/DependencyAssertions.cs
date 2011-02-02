using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Prova.Tests.ForTestable
{
    [Binding]
    public class DependencyAssertions
    {
        private readonly TestableContext _context;

        public DependencyAssertions(TestableContext context)
        {
            _context = context;
        }

        [Then(@"I should have a dependency that is not null")]
        public void ThenIShouldHaveADependencyThatIsNotNull()
        {
            Assert.That(_context.FirstInstance.Dependency, Is.Not.Null);
        }
    }
}