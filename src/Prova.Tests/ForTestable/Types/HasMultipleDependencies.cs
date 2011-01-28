namespace Prova.Tests.ForTestable.Types
{
    public class HasMultipleDependencies
    {
        public readonly IDefaultDependency ShouldBeDefault;
        public readonly IExplicitDependency ShouldBeExplicit;
        public readonly IImplicityDependency ShouldBeImplicit;
        public readonly IMockedDependency ShouldBeMocked;

        public HasMultipleDependencies(IDefaultDependency shouldBeDefault,
                                       IExplicitDependency shouldBeExplicit,
                                       IImplicityDependency shouldBeStubbed,
                                       IMockedDependency shouldBeMocked)
        {
            ShouldBeDefault = shouldBeDefault;
            ShouldBeExplicit = shouldBeExplicit;
            ShouldBeImplicit = shouldBeStubbed;
            ShouldBeMocked = shouldBeMocked;
        }
    }

    public interface IDefaultDependency
    {
    }

    public class DefaultDependency : IDefaultDependency
    {
    }

    public interface IExplicitDependency
    {
    }

    public class ExplicitDependency : IExplicitDependency
    {
    }

    public interface IImplicityDependency
    {
    }

    public class CannedImplicityDependency : IImplicityDependency
    {
    }

    public interface IMockedDependency
    {
    }
}