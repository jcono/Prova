using System;
using Prova.Testables;

namespace Prova
{
    public class Testable<T> : Testable
    {
        public Testable() : base(typeof(T))
        {
        }

        public new T Create()
        {
            return base.Create();
        }

    }

    public class Testable
    {
        private readonly Constructor _constructor;
        private readonly Dependencies _dependencies;
        private readonly Type _type;

        public Testable(Type type)
        {
            _type = type;
            _constructor = new Constructor(_type);
            _dependencies = new Dependencies(_type);
        }

        public static DefaultDependencies InstancesOf(Type type)
        {
            return DefaultDependencyLookup.On(type);
        }

        public Testable With(dynamic dependency)
        {
            MustHaveParameterFor(TypeOf(dependency));

            _dependencies.Add(dependency);
            return this;
        }

        public dynamic Create()
        {
            return _constructor.InvokeUsing(_dependencies);
        }

        private void MustHaveParameterFor(Type parameterType)
        {
            if (!_constructor.HasParameterFor(parameterType))
            {
                throw new ArgumentException($"The constructor of the type [{_type}] does not contain a dependency assignable from type [{parameterType}]");
            }
        }

        private static Type TypeOf(dynamic dependency)
        {
            return dependency.GetType();
        }
    }
}
