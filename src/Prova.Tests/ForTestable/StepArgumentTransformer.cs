using System;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Prova.Tests.ForTestable
{
    [Binding]
    public class StepArgumentTransformer
    {
        [StepArgumentTransformation]
        public Type TransformType(string expr)
        {
            return Type.GetType(expr, true, true);
        }
    }
}