using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Prova.Testables
{
    public class Parameters
    {
        private readonly IEnumerable<Type> _parameters;

        public Parameters(ConstructorInfo constructor)
        {
            _parameters = SelectAll(ParametersForThe(constructor), ByParameterType);
        }

        public bool HasParameterFor(Type type)
        {
            return _parameters.Any(x => x.IsAssignableFrom(type));
        }

        public IEnumerable<dynamic> BuildInstancesUsing(Dependencies dependencies)
        {
            return _parameters.Select(dependencies.InstanceForType);
        }

        private static IEnumerable<Type> SelectAll(IEnumerable<ParameterInfo> parametersInformation,
                                                   Func<ParameterInfo, Type> selector)
        {
            return parametersInformation.Select(selector);
        }

        private static IEnumerable<ParameterInfo> ParametersForThe(ConstructorInfo constructor)
        {
            return constructor.GetParameters();
        }

        private static Type ByParameterType(ParameterInfo parameter)
        {
            return parameter.ParameterType;
        }

        public Type Find(Type parameterType)
        {
            return _parameters.SingleOrDefault(x => x.IsAssignableFrom(parameterType));
        }
    }
}
