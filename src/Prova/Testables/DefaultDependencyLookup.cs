﻿using System;
using System.Collections.Generic;

namespace Prova.Testables
{
    public static class DefaultDependencyLookup
    {
        private static readonly IDictionary<Type, DefaultDependencies> Lookup = new Dictionary<Type, DefaultDependencies>();

        public static DefaultDependencies On(Type type)
        {
            if (!Lookup.ContainsKey(type))
            {
                Lookup.Add(type, new DefaultDependencies());
            }
            return Lookup[type];
        }
    }
}