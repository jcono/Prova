using System;
using System.Collections.Generic;
using System.Linq;
using Prova.Extensions;
using Rhino.Mocks;

namespace Prova.Testables
{
    public sealed class Dependencies
    {
        private readonly Type _type;
        private readonly ICollection<dynamic> _dependencies = new List<dynamic>();

        public Dependencies(Type type)
        {
            _type = type;
        }

        public void Add(dynamic dependency)
        {
            _dependencies.Add(dependency);
        }

        private dynamic GetRegisteredInstanceFor(Type type)
        {
            return _dependencies.SingleOrDefault(type.IsInstanceOfType);
        }

        private dynamic GetDefaultInstanceFor(Type type)
        {
//            return null;
            return DefaultDependencyLookup.On(_type).For(type);
        }

        private static dynamic GetStubbedInstanceFor(Type type)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var allTypes = assemblies.SelectMany(a => a.GetTypes());
            var typesThatImplement = allTypes.Where(x => x.GetInterfaces().Any(i => i == type));
            var canned = typesThatImplement.FirstOrDefault(x => x.Name.StartsWith("Canned"));
            if (canned.IsNotNothing())
            {
                return canned.GetConstructors().FirstOrDefault().Invoke(new object[] {});
            }
            return null;
        }

        private static dynamic GetMockLibraryInstanceFor(Type type)
        {
            return MockRepository.GenerateStub(type);
        }

        public dynamic InstanceForType(Type type)
        {
            return GetRegisteredInstanceFor(type)
                   ?? GetDefaultInstanceFor(type)
                   ?? GetStubbedInstanceFor(type)
                   ?? GetMockLibraryInstanceFor(type);
        }
    }
}