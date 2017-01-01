namespace Prova.Tests.ForTestable.Types
{
    public class InvalidDependency { }

    public interface IDependency {}
    public class Dependency : IDependency { }
    public class DifferentDependency : IDependency { }
    public class StubDependency : IDependency { }
    //    public class CannedDependency : IDependency { }

    public interface IDefaultDependency { }

}
