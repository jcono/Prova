using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Prova.Tests.ForTestable
{
    [Binding]
    public class StepArgumentTransformer
    {
        private static readonly IEnumerable<Type> AllLoadedTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes());

        [StepArgumentTransformation("type of (.*)")]
        public Type TransformType(string typeName)
        {
            return AllLoadedTypes.FirstOrDefault(x => x.Name == typeName);
        }
    }
}