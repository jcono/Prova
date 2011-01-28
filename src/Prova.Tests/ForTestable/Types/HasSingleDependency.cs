namespace Prova.Tests.ForTestable.Types
{
    public class HasSingleDependency
    {
        public readonly IDependency Dependency;

        public HasSingleDependency(IDependency dependency)
        {
            Dependency = dependency;
        }
    }
}