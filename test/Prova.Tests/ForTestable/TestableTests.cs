using System;
using NUnit.Framework;
using Prova.Tests.ForTestable.Types;

namespace Prova.Tests.ForTestable
{
    public class TestableTests
    {
        [Test]
        public void CanNotUseAbstractType()
        {
            Assert.That(() => new Testable<AbstractClass>(), Throws.ArgumentException);
        }

        [Test]
        public void CanNotUseTypeWithAmbiguousConstructor()
        {
            Assert.That(() => new Testable<AmbiguousConstructor>(), Throws.ArgumentException);
        }

        [Test]
        public void CanNotUseTypeWithMultipleConstructors()
        {
            Assert.That(() => new Testable<MultipleConstructors>(), Throws.ArgumentException);
        }

        [Test]
        public void CanUseTypeWithoutExplicitConstructor()
        {
            var testable = new Testable<NoExplicitConstructor>();

            Assert.That(testable.Create(), Is.InstanceOf<NoExplicitConstructor>());
        }

        [Test]
        public void CanUseTypeWithExplicitConstructor()
        {
            var testable = new Testable<SingleDependency>();

            Assert.That(testable.Create(), Is.InstanceOf<SingleDependency>());
        }

        [Test]
        public void CanNotProvideAnInvalidDependency()
        {
            var testable = new Testable<SingleDependency>();

            Assert.That(() => testable.With(new InvalidDependency()), Throws.ArgumentException);
        }

        [Test]
        public void CanImplicitlyProvideDependencies()
        {
            var testable = new Testable<SingleDependency>();

            Assert.That(testable.Create().Dependency, Is.Not.Null);
        }

        [Test]
        public void CanExplicitlyProvideDependencies()
        {
            var testable = new Testable<SingleDependency>();
            var dependency = new Dependency();

            testable.With(dependency);

            Assert.That(testable.Create().Dependency, Is.EqualTo(dependency));
        }

        [Test]
        public void CanNotProvideInvalidDefaultDependency()
        {
            Assert.That(Testable.InstancesOf<SingleDependency>().UseDefaultOf<InvalidDependency>, Throws.ArgumentException);
//            Assert.That(Testable<SingleDependency>.InstancesOf().UseDefaultOf<InvalidDependency>, Throws.ArgumentException);
        }

        [Test]
        public void CanProvideTypeAsDefaultDependency()
        {
            Testable.InstancesOf<SingleDependency>().UseNoDefaults();
            Testable.InstancesOf<SingleDependency>().UseDefaultOf<Dependency>();

            var testable = new Testable<SingleDependency>();

            Assert.That(testable.Create().Dependency, Is.TypeOf<Dependency>());
        }

        [Test]
        public void CanProvideFunctionAsDefaultDependency()
        {
            Testable.InstancesOf<SingleDependency>().UseNoDefaults();
            Testable.InstancesOf<SingleDependency>().UseDefaultOf(Activator.CreateInstance<StubDependency>);
            var testable = new Testable<SingleDependency>();

            Assert.That(testable.Create().Dependency, Is.TypeOf<StubDependency>());
        }
    }
}