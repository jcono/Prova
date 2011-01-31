using System;
using NUnit.Framework;
using Prova.Extensions;
using Prova.Tests.ForTestable.Types;
using TechTalk.SpecFlow;

namespace Prova.Tests.ForTestable
{
    [Binding]
    [StepScope(Tag = "Invalid_Dependencies")]
    public class InvalidDependenciesStepDefinitions
    {
        private Testable _testable;
        private Exception _exception;

        [Given(@"I have a testable (.*)")]
        public void GivenIHaveATestable(Type type)
        {
            _testable = new Testable(type);
        }

        [When(@"I tell the object to use an incorrect dependency")]
        public void WhenITellTheObjectToUse()
        {
            Action action = () => _testable.With(new UnusedDependency());
            _exception = action.GetException();
        }

        [Then(@"I should have seen a[n]* (.*)")]
        public void ThenIShouldHaveSeenAn(Type expectedExceptionType)
        {
            Assert.That(_exception, Is.InstanceOf(expectedExceptionType));
        }
    }
}