using System;
using Prova.Extensions;
using Prova.Testables;

namespace Prova
{
    public class Testable<T> : Testable
    {
        public Testable() : base(typeof(T)) { }

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

        public static DefaultDependencies InstancesOf<T>() => DefaultDependencyLookup.On(typeof(T));

        public Testable With(dynamic dependency)
        {
            Type parameterType = TypeOf(dependency);
            if (_constructor.TypeOfParameterFor(parameterType).IsNothing())
            {
                throw _constructor.Type.HasNoMatchingParameterException(parameterType);
            }

            _dependencies.Add(dependency);
            return this;
        }

        public dynamic Create() => _constructor.InvokeUsing(_dependencies);

        private static Type TypeOf(dynamic dependency) => dependency.GetType();
    }
}