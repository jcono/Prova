using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Prova.Tests.ForTestable
{
    [Binding]
    public class TypeRestrictionSteps
    {
        private readonly TestableContext _context;

        public TypeRestrictionSteps(TestableContext context)
        {
            _context = context;
        }

        [Then(@"I should have a testable instance with (.*)")]
        public void ShouldHaveTestableInstanceWith(Type type)
        {
            Assert.That(_context.FirstInstance, Is.InstanceOf(type));
        }

       
    }
}