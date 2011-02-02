using System;
using Prova.Resources;
using Prova.Testables;

namespace Prova
{
    public class Testable
    {
//        public static DefaultDependencies InstancesOf(Type type)
//        {
//            return DefaultDependencyLookup.On(type);
//        }

        private readonly Type _type;
        private readonly Constructor _constructor;
        private readonly Dependencies _dependencies;

        public Testable(Type type)
        {
            _type = type;
            _constructor = new Constructor(_type);
            _dependencies = new Dependencies(_type);
        }

        public dynamic With(dynamic dependency)
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
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidDependency, _type, parameterType));
            }
        }

        private static Type TypeOf(dynamic dependency)
        {
            return dependency.GetType();
        }
    }
}