using System;
using System.Collections.Generic;
using System.Linq;
using Prova.Extensions;

namespace Prova.Testables
{
    public class DefaultDependencies
    {
        private readonly Type _type;
        private readonly IDictionary<Type, dynamic> _defaults = new Dictionary<Type, dynamic>();

        internal DefaultDependencies(Type type)
        {
            _type = type;
        }

        public void UseDefaultOf<T>()
        {
            UseDefaultOf(Activator.CreateInstance<T>);
        }

        public void UseDefaultOf<T>(Func<T> function)
        {
            var constructor = new Constructor(_type);
            var parameterType = constructor.TypeOfParameterFor(typeof(T));
            if (parameterType.IsNothing()) { constructor.NoMatchingParameterException(parameterType); }

            if (_defaults.ContainsKey(parameterType))
            {
                _defaults[parameterType] = function;
            }
            else
            {
                _defaults.Add(parameterType, function);
            }
        }

        public dynamic InstanceFor(Type type)
        {
            var key = _defaults.Keys.SingleOrDefault(type.IsAssignableFrom);
            return key.IsNotNothing() ? _defaults[key]() : default(dynamic);
        }
    }
}