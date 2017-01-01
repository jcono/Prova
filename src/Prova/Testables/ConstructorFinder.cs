using System;
using System.Linq;
using System.Reflection;
using Prova.Extensions;
//using Prova.Resources;

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
            if (_type.IsAbstract)
            {
                throw new ArgumentException($"The type [{_type.Name}] is an abstract class.");
            }
            var constructors = _type.GetConstructors().Where(ParameterTypesAreUnique);
            if (!constructors.HasCountOf(1))
            {
                throw new ArgumentException($"Type [{_type.Name}] must have a valid public constructor with uniquely typed parameters.");
            }
            return constructors.Single();
        }

        private static bool ParameterTypesAreUnique(ConstructorInfo constructor)
        {
            return constructor.GetParameters().Select(p => p.ParameterType).AreUnique();
        }
    }
}
