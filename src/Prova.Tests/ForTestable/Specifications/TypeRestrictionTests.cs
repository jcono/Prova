using System;
using NUnit.Framework;
using Prova.Tests.ForTestable.Types;

namespace Prova.Tests.ForTestable.Specifications
{
    [TestFixture]
    public class TypeRestrictionTests : Specification<TypeRestrictionTestsState>
    {
        [Test]
        public void ShouldBeAbleToUseATypeWithAStaticConstructor()
        {
            Given(I.TryAndCreateATestableWith(typeof(HasStaticConstructor)))
                .When(I.LookForAn<Exception>)
                .Then(I.ShouldHaveAnInstanceOf<HasStaticConstructor>)
                .And(I.ShouldNotHaveAnException);
        }

        [Test]
        public void ShouldBeAbleToUseATypeWithNoConstructor()
        {
            Given(I.TryAndCreateATestableWith(typeof(HasNoExplicitConstructor)))
                .When(I.LookForAn<Exception>)
                .Then(I.ShouldHaveAnInstanceOf<HasNoExplicitConstructor>)
                .And(I.ShouldNotHaveAnException);
        }

        [Test]
        public void ShouldNotBeAbleToUseAnAbstractClass()
        {
            Given(I.TryAndCreateATestableWith(typeof(AbstractClass)))
                .When(I.LookForAn<ArgumentException>)
                .Then(I.ShouldHaveSeenThatException);
        }

        [Test]
        public void ShouldNotBeAbleToUseATypeWithAnAmbiguousConstructor()
        {
            Given(I.TryAndCreateATestableWith(typeof(AmbiguousConstructor)))
                .When(I.LookForAn<ArgumentException>)
                .Then(I.ShouldHaveSeenThatException);
        }

        [Test]
        public void ShouldNotBeAbleToUseATypeWithTooManyConstructors()
        {
            Given(I.TryAndCreateATestableWith(typeof(HasTooManyConstructors)))
                .When(I.LookForAn<ArgumentException>)
                .Then(I.ShouldHaveSeenThatException);
        }
    }
}