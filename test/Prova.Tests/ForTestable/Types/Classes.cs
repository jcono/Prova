using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Prova.Tests.ForTestable.Types
{
    public abstract class AbstractClass
    {
        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        protected AbstractClass(IDependency dependency) { }
    }

    [UsedImplicitly]
    public class NoExplicitConstructor { }

    [UsedImplicitly]
    public class AmbiguousConstructor
    {
        public AmbiguousConstructor(IDependency dependency1, IDependency dependency2) { }
    }

    [UsedImplicitly]
    public class SingleDependency
    {
        public SingleDependency(IDependency dependency) { Dependency = dependency; }

        [UsedImplicitly]
        public IDependency Dependency { get; }
    }

    [UsedImplicitly]
    public class MultipleConstructors
    {
        public MultipleConstructors() { }

        public MultipleConstructors(IDependency dependency) { }
    }
}
