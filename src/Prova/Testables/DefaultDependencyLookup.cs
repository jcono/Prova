using System;
using System.Collections.Generic;

namespace Prova.Testables
{
    public static class DefaultDependencyLookup
    {
        private static readonly IDictionary<Type, dynamic> Lookup = new Dictionary<Type, dynamic>();

        public static dynamic On(Type type)
        {
            if (!Lookup.ContainsKey(type))
            {
                Lookup.Add(type, new DefaultDependencies(type));
            }
            return Lookup[type];
        }
    }
}
