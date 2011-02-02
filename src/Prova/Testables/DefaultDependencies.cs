using System;
using System.Collections.Generic;
using System.Linq;
using Prova.Extensions;

namespace Prova.Testables
{
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