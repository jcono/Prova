using System;
using NUnit.Framework;
using Prova.Tests.ForTestable.Types;

namespace Prova.Tests.ForTestable.Specifications
{
    [TestFixture]
    public class DependencyRestrictionTests : Specification<DependencyRestrictionTestState>
    {
        [Test]
        public void ShouldNotBeAbleToProvideDependencyThatCanNotBeInjected()
        {
            Given(I.HaveATestableObject)
                .When(I.TellTheObjectToUse(new UnusedDependency()))
                .And(I.LookForAnExceptionWith(typeof(ArgumentException)))
                .Then(I.ShouldHaveSeenThatException);
        }
    }
}