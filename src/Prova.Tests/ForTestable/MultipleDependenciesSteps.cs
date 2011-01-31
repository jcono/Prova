﻿using System;
using NUnit.Framework;
using Prova.Tests.ForTestable.Types;
using Rhino.Mocks;
using TechTalk.SpecFlow;

namespace Prova.Tests.ForTestable
{
    [Binding]
    [StepScope(Feature = "Can automatically provide different ways of obtaining dependencies for a type with multiple dependencies")]
    public class MultipleDependenciesSteps
    {
        private Testable _testable;
        private HasMultipleDependencies _instance;

        [Given(@"I specify that testable instances use a default dependency")]
        public void GivenISpecifyThatInstancesUseDefaultDependency()
        {
            Testable.InstancesOf(typeof(HasMultipleDependencies)).UsesDefault(() => new DefaultDependency());
        }

        [Given(@"I have a testable with a (.*)")]
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
            Assert.That(_instance.ShouldBeImplicit, Is.InstanceOf(typeof(CannedImplicitDependency)));
        }

        [Then(@"I should have a mocked dependency")]
        public void ThenIShouldHaveAMockedDependency()
        {
            Assert.That(_instance.ShouldBeMocked, Is.InstanceOf(MockRepository.GenerateStub<IMockedDependency>().GetType()));
        }
    }
}