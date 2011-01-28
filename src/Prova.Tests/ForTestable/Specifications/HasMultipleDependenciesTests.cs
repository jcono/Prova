using NUnit.Framework;
using Prova.Tests.ForTestable.Types;

namespace Prova.Tests.ForTestable.Specifications
{
    [TestFixture]
    public class HasMultipleDependenciesTests : Specification<HasMultipleDependenciesTestsState>
    {
        [Test]
        public void ShouldGetAllTypesOfDependencies()
        {
            var explicitDependency = new ExplicitDependency();

            Given(I.ProvideADefaultDependencyOf(NewDefaultDependency))
                .And(I.HaveATestableObject)
                .And(I.ProvideADependencyOf(explicitDependency));
            When(I.UseTheTestableInstance);
            Then(I.ShouldHaveADefaultDependencyWith(typeof(DefaultDependency)))
                .And(I.ShouldHaveAnExplicitDependencyThatIs(explicitDependency))
                .And(I.ShouldHaveACannedDependencyWith(typeof(CannedImplicityDependency)))
                .And(I.ShouldHaveAMockedDependency);
        }

        private static DefaultDependency NewDefaultDependency()
        {
            return new DefaultDependency();
        }
    }
}