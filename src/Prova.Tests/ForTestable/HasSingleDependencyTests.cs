using NUnit.Framework;
using Prova.Tests.ForTestable.Types;

namespace Prova.Tests.ForTestable
{
    [TestFixture]
    public class HasSingleDependencyTests : Specification<HasSingleDependencyTestsState>
    {
        [Test]
        public void ShouldBeAbleToGetADependencyImplicitlyFromTheLoadedAssemblies()
        {
            Given(I.HaveATestableObject);
            When(I.UseTheTestableInstance);
            Then(I.HaveAnInstanceWithACannedDependency);
        }

        [Test]
        public void ShouldBeAbleToGetAnImplicitDependency()
        {
            Given(I.HaveATestableObject);
            When(I.UseTheTestableInstance);
            Then(I.HaveAnInstanceWithADependencyThatIsNotNull);
        }

        [Test]
        public void ShouldBeAbleToRegisterADefaultDependency()
        {
            Given(I.WantToUseADefaultOf(NewDependency)).And(I.HaveATestableObject);
            When(I.UseTheTestableInstance);
            Then(I.HaveAnInstanceThatUsesThe(typeof(Dependency)));
        }

        [Test]
        public void ShouldBeAbleToSetAnExplicitDependency()
        {
            var dependency = new StubDependency();

            Given(I.HaveATestableObject);
            When(I.TellTheObjectToUse(dependency)).And(I.UseTheTestableInstance);
            Then(I.HaveAnInstanceThatUsesThe(dependency));
        }

        [Test]
        public void ShouldHaveANewDefaultDependencyForDifferentInstances()
        {
            Given(I.WantToUseADefaultOf(() => new Dependency())).And(I.HaveATestableObject).And(I.HaveASecondTestableObject);
            When(I.UseTheTestableInstance).And(I.UseTheSecondTestableInstance);
            Then(I.TheTwoInstanceShouldHaveDifferent<Dependency>());
        }

        private static Dependency NewDependency()
        {
            return new Dependency();
        }
    }
}