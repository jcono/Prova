namespace Prova.Tests.ForTestable.Types
{
    public abstract class AbstractClass
    {
        protected AbstractClass(IDependency dependency) { }
    }

    public class NoExplicitConstructor { }

    public class AmbiguousConstructor
    {
        public AmbiguousConstructor(IDependency dependency1, IDependency dependency2) { }
    }

    public class SingleDependency
    {
        public readonly IDependency Dependency;

        public SingleDependency(IDependency dependency)
        {
            Dependency = dependency;
        }
    }

    public class MultipleConstructors
    {
        public MultipleConstructors() { }

        public MultipleConstructors(IDependency dependency) { }
    }
}