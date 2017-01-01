using System;
using System.Linq;
using System.Reflection;
using Prova.Extensions;

namespace Prova.Testables
{
    public class ConstructorFinder
    {
        private readonly Type _type;

        public ConstructorFinder(Type type)
        {
            _type = type;
        }

        public ConstructorInfo Find()
        {
            if (_type.IsAbstract) { throw _type.IsAbstractException(); }

            var constructors = _type.GetConstructors().Where(ParameterTypesAreUnique).ToList();
            if (!constructors.HasCountOf(1)) { throw _type.TooManyConstructorsException(); }

            return constructors.Single();
        }

        private static bool ParameterTypesAreUnique(ConstructorInfo constructor)
        {
            return constructor.GetParameters().Select(p => p.ParameterType).AreUnique();
        }
    }
}