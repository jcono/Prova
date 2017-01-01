using System;
using NUnit.Framework;
using Prova.Tests.ForTestable.Types;

namespace Prova.Tests.ForTestable
{
    public class TestableTests
    {
        [Test]
        public void CanUseTypeWithOnlyStaticConstructor()
        {
            var testable = new Testable<HasStaticConstructor>();

            Assert.That(testable.Create(), Is.InstanceOf<HasStaticConstructor>());
        }

        [Test]
        public void CanUseTypeWithoutExplicitConstructor()
        {
            var testable = new Testable<HasNoExplicitConstructor>();

            Assert.That(testable.Create(), Is.InstanceOf<HasNoExplicitConstructor>());
        }

        [Test]
        public void CanNotUseAbstractType()
        {
            Assert.That(() => new Testable<AbstractClass>(), Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void CanNotUseTypeWithAmbiguousConstructor()
        {
            Assert.That(() => new Testable<AmbiguousConstructor>(), Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void CanNotUseTypeWithMultipleConstructors()
        {
            Assert.That(() => new Testable<HasTooManyConstructors>(), Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void CanImplicitlyResolveDependencies()
        {
            var testable = new Testable<HasSingleDependency>();

            var instance = testable.Create();

            Assert.That(instance.Dependency, Is.Not.Null);
            Assert.That(instance.Dependency, Is.Not.TypeOf<Dependency>());
            Assert.That(instance.Dependency, Is.Not.TypeOf<DifferentDependency>());
            Assert.That(instance.Dependency, Is.Not.TypeOf<StubDependency>());
        }

    }
}