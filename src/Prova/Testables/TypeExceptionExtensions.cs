using System;

namespace Prova.Testables
{
    public static class TypeExceptionExtensions
    {
        public static ArgumentException HasNoMatchingParameterException(this Type type, Type parameterType)
        {
            return new ArgumentException($"The constructor of the type [{type.Name}] does not contain a dependency assignable from type [{parameterType}]");
        }

        public static ArgumentException IsAbstractException(this Type type)
        {
            return new ArgumentException($"The type [{type.Name}] is an abstract class.");
        }

        public static ArgumentException TooManyConstructorsException(this Type type)
        {
            return new ArgumentException($"Type [{type.Name}] must have a valid public constructor with uniquely typed parameters.");
        }
    }
}