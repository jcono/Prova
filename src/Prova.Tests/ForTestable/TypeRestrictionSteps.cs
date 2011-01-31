using System;
using NUnit.Framework;
using Prova.Extensions;
using TechTalk.SpecFlow;

namespace Prova.Tests.ForTestable
{
    [Binding]
    [StepScope(Feature = "Restrict the types that testable can create")]
    public class TypeRestrictionSteps
    {
        private dynamic _instance;
        private Exception _exception;

        [When(@"I try and create a testable with (.*)")]
        public void TryAndCreateATestableWith(Type type)
        {
            Action action = () => _instance = new Testable(type).Create();
            _exception = action.GetException();
        }

        [Then(@"I should have a testable instance with (.*)")]
        public void HaveTestableInstanceWith(Type type)
        {
            Assert.That(_instance, Is.InstanceOf(type));
        }

        [Then(@"I should have seen an exception with a (.*)")]
        public void ThenIShouldHaveSeenAnExceptionWith(Type type)
        {
            Assert.That(_exception, Is.InstanceOf(type));
        }


    }
}