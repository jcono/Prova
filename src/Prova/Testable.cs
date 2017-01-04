using System;
using Prova.Extensions;
using Prova.Testables;

namespace Prova
{
    public static class Testable
    {
        public static DefaultDependencies InstancesOf<T>() => DefaultDependencyLookup.On(typeof(T));
    }

    public class Testable<T>
    {
        private readonly Constructor _constructor;
        private readonly Dependencies _dependencies;

        public Testable()
        {
            _constructor = new Constructor(typeof(T));
            _dependencies = new Dependencies(typeof(T));
        }


        public dynamic With(dynamic dependency)
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
