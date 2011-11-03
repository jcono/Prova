using System;
using System.Collections.Generic;
using System.Linq;
using Prova.Extensions;

namespace Prova.Testables
{
    public class DefaultDependencies
    {
        private readonly IDictionary<Type, Func<dynamic>> _defaults = new Dictionary<Type, Func<dynamic>>();

        internal DefaultDependencies()
        {
        }

        public void UseNoDefaults()
        {
            _defaults.Clear();
        }

        public void UseDefaultOf(Type dependencyType)
        {
            _defaults.Add(dependencyType, () => Activator.CreateInstance(dependencyType));
        }

        public void UseDefaultOf(Func<dynamic> function)
        {
            _defaults.Add(function.Method.ReturnType, function);
        }

        public dynamic InstanceFor(Type type)
        {
            var key = _defaults.Keys.SingleOrDefault(type.IsAssignableFrom);
            return key.IsNotNothing() ? _defaults[key]() : default(dynamic);
        }
    }
}