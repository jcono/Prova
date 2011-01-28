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
//            if (_type.IsAbstract)
//            {
//                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBeAnAbstractClass, _type.Name));
//            }
            var constructors = _type.GetConstructors();//.Where(ParameterTypesAreUnique);
//            if (!constructors.HasCountOf(1))
//            {
//                throw new ArgumentException(string.Format(ExceptionMessages.MustHaveValidConstructor, _type.Name));
//            }
            return constructors.Single();
        }

        private static bool ParameterTypesAreUnique(ConstructorInfo constructor)
        {
            return constructor.GetParameters().Select(p => p.ParameterType).AreUnique();
        }
    }
}