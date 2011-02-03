using System;
using System.Collections.Generic;

namespace Prova.Testables
{
    public class DefaultDependencies
    {
        private static readonly IDictionary<Type, DefaultDependencies> AllDefaults = new Dictionary<Type, DefaultDependencies>();

        public static DefaultDependencies For(Type type)
        {
            if (!AllDefaults.ContainsKey(type))
            {
                AllDefaults.Add(type, new DefaultDependencies(type));
            }
            return AllDefaults[type];
        }

        private readonly Type _type;
        private readonly IDictionary<Type, Func<dynamic>> _dependencies = new Dictionary<Type, Func<dynamic>>();

        private DefaultDependencies(Type type)
        {
            _type = type;
        }

        public void UseDefaultOf(Type dependencyType)
        {
            _dependencies.Add(dependencyType, () => Activator.CreateInstance(dependencyType));
        }

        public void UseNoDefaults()
        {
            _dependencies.Clear();
        }

        public void UseDefaultOf(Func<dynamic> function)
        {
            _dependencies.Add(function.Method.ReturnType, function);
        }
    }


//    public class DefaultDependencies
//    {
//        private readonly IDictionary<Type, Func<dynamic>> _defaults = new Dictionary<Type, Func<dynamic>>();
//
//        public void UsesDefault<T>(Func<T> value)
//        {
//            var key = typeof(T);
//            if (_defaults.ContainsKey(key))
//            {
//                _defaults[key] = (dynamic)value;
//            }
//            else
//            {
//                _defaults.Add(key, (dynamic)value);
//            }
//        }
//
//        public void DoNotUseDefaults()
//        {
//            _defaults.Clear();
//        }
//
//        internal dynamic For(Type type)
//        {
//            return ValueFor(TheKey(ThatIsAssignableFrom(type)));
//        }
//
//        private dynamic ValueFor(Type key)
//        {
//            return key.IsNotNothing() ? _defaults[key]() : default(dynamic);
//        }
//
//        private static Func<Type, bool> ThatIsAssignableFrom(Type type)
//        {
//            return type.IsAssignableFrom;
//        }
//
//        private Type TheKey(Func<Type, bool> where)
//        {
//            return _defaults.Keys.SingleOrDefault(where);
//        }
//    }
}