using System;
using NUnit.Framework;
using Prova.Specifications;
using Prova.Tests.ForTestable.Types;

namespace Prova.Tests.ForTestable
{
    [TestFixture]
    public class DependencyRestrictionTests : Specification<DependencyRestrictionTestState>
    {
        [Test]
        public void ShouldNotBeAbleToProvideDependencyThatCanNotBeInjected()
        {
            var unusedDependency = new UnusedDependency();

            Given(I.HaveATestableObject)
                .When(I.TellTheObjectToUse(unusedDependency))
                .And(I.LookForAnExceptionWith(typeof(ArgumentException)))
                .Then(I.ShouldHaveSeenThatException);
        }
    }
}