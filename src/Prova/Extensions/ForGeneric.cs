namespace Prova.Extensions
{
    public static class ForGeneric
    {
        public static bool IsNothing<T>(this T instance) => Equals(instance, default(T));

        public static bool IsNotNothing<T>(this T instance) => !instance.IsNothing();
    }
}
