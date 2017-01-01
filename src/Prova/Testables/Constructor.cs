using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Prova.Testables
{
    public class Constructor
    {
        private readonly ConstructorInfo _constructor;
        private readonly Parameters _parameters;

        public Constructor(Type type)
        {
            Type = type;
            _constructor = new ConstructorFinder(type).Find();
            _parameters = new Parameters(_constructor);
        }

        public Type Type { get; }

        public dynamic InvokeUsing(Dependencies dependencies)
        {
            var parameters = _parameters.BuildInstancesUsing(dependencies);
            return _constructor.Invoke(UsingArrayOf(parameters));
        }

        private static object[] UsingArrayOf(IEnumerable<object> types)
        {
            return types.ToArray();
        }

        public bool HasParameterFor(Type dependencyType)
        {
            return _parameters.HasParameterFor(dependencyType);
        }

        public Type TypeOfParameterFor(Type parameterType)
        {
            return _parameters.Find(parameterType);
        }
    }
}