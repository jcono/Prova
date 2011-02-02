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

        [Given(@"I create a testable with a (.*)")]
        [When(@"I create a testable with a (.*)")]
        public void CreateTestableWith(Type type)
        {
            Action action = () =>
            {
                _context.FirstTestable = new Testable(type);
                _context.FirstInstance = _context.FirstTestable.Create();
            };
            _context.Exception = action.GetException();
        }

        [When(@"I want to use the testable instance")]
        public void UseTheTestableObject()
        {
            _context.FirstInstance = _context.FirstTestable.Create();
        }

        [Then(@"I should have seen an exception with a (.*)")]
        public void ShouldHaveSeenAnExceptionWith(Type type)
        {
            Assert.That(_context.Exception, Is.InstanceOf(type));
        }
    }
}