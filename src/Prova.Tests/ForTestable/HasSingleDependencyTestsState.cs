using System;
using NUnit.Framework;
using Prova.Tests.ForTestable.Types;

namespace Prova.Tests.ForTestable
{
    public class HasSingleDependencyTestsState
    {
        private HasSingleDependency _secondInstance;
        private Testable _secondTestable;
        private Testable _testable;
        private HasSingleDependency _theInstance;

        public void HaveATestableObject()
        {
            _testable = new Testable(typeof(HasSingleDependency));
        }

        public Action TellTheObjectToUse<TDependency>(TDependency dependency)
        {
            return () => _testable.With(dependency);
        }

        public void UseTheTestableInstance()
        {
            _theInstance = _testable.Create();
        }

        public Action WantToUseADefaultOf<T>(Func<T> activator)
        {
            return () => Testable.InstanceOf(typeof(HasSingleDependency)).UsesDefault(activator);
        }

        public Action HaveAnInstanceThatUsesThe(IDependency dependency)
        {
            return () => Assert.That(_theInstance.Dependency, Is.EqualTo(dependency));
        }

        public Action HaveAnInstanceThatUsesThe(Type expectedType)
        {
            return () => Assert.That(_theInstance.Dependency, Is.InstanceOf(expectedType));
        }

        public void HaveAnInstanceWithADependencyThatIsNotNull()
        {
            Assert.That(_theInstance.Dependency, Is.Not.Null);
        }

        public void HaveAnInstanceWithACannedDependency()
        {
            Assert.That(_theInstance.Dependency, Is.InstanceOf(typeof(CannedDependency)));
        }

        public void HaveASecondTestableObject()
        {
            _secondTestable = new Testable(typeof(HasSingleDependency));
        }

        public void UseTheSecondTestableInstance()
        {
            _secondInstance = _secondTestable.Create();
        }

        public Action TheTwoInstanceShouldHaveDifferent<T>()
        {
            return () =>
            {
                Assert.That(_theInstance.Dependency, Is.InstanceOf(typeof(T)));
                Assert.That(_secondInstance.Dependency, Is.InstanceOf(typeof(T)));
                Assert.That(_theInstance.Dependency, Is.Not.EqualTo(_secondInstance.Dependency));
            };
        }
    }
}