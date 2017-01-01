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

        public void UseNoDefaults() => _defaults.Clear();

        public void UseDefaultOf<T>()
        {
            UseDefaultOf(typeof(T), () => (T)Activator.CreateInstance(typeof(T)));
        }

        public void UseDefaultOf<T>(Func<T> function)
        {
            UseDefaultOf(typeof(T), function);
        }

        private void UseDefaultOf<T>(Type parameterType, Func<T> function)
        {
            var constructor = new Constructor(_type);

            constructor.MustHaveParameterFor(parameterType);

            var t = constructor.TypeOfParameterFor(parameterType);

            if (_defaults.ContainsKey(t))
            {
                _defaults[t] = function;
            }
            else
            {
                _defaults.Add(t, function);
            }
        }

        public dynamic InstanceFor(Type type)
        {
            var key = _defaults.Keys.SingleOrDefault(type.IsAssignableFrom);
            return key.IsNotNothing() ? _defaults[key]() : default(dynamic);
        }
    }
}