using System;
using NUnit.Framework;
using Prova.Tests.ForTestable.Types;
using Rhino.Mocks;

namespace Prova.Tests.ForTestable.Specifications
{
    public class MultipleDependenciesTestsState
    {
        private HasMultipleDependencies _instance;
        private Testable _testable;

        public Action ProvideADefaultDependencyOf<T>(Func<T> activator) where T : new()
        {
            return () => Testable.InstancesOf(typeof(HasMultipleDependencies)).UsesDefault(activator);
        }

        public void HaveATestableObject()
        {
            _testable = new Testable(typeof(HasMultipleDependencies));
        }

        public Action ProvideADependencyOf(dynamic dependency)
        {
            return () => _testable.With(dependency);
        }

        public void UseTheTestableInstance()
        {
            _instance = _testable.Create();
        }

        public Action ShouldHaveADefaultDependencyWith(Type expectedType)
        {
            return () => Assert.That(_instance.ShouldBeDefault, Is.InstanceOf(expectedType));
        }

        public Action ShouldHaveAnExplicitDependencyThatIs(IExplicitDependency dependency)
        {
            return () => Assert.That(_instance.ShouldBeExplicit, Is.EqualTo(dependency));
        }

        public Action ShouldHaveACannedDependencyWith(Type expectedType)
        {
            return () => Assert.That(_instance.ShouldBeImplicit, Is.InstanceOf(expectedType));
        }

        public void ShouldHaveAMockedDependency()
        {
            Assert.That(_instance.ShouldBeMocked, Is.InstanceOf(MockRepository.GenerateStub<IMockedDependency>().GetType()));
        }
    }
}