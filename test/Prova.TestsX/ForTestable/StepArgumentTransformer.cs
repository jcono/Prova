﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Prova.Tests.ForTestable
{
//    [Binding]
    public class StepArgumentTransformer
    {
        private static readonly IEnumerable<Type> AllLoadedTypes = new Type[] {};
//            AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes());

//        [StepArgumentTransformation("type (.*)")]
        private Type TransformToType(string typeName)
        {
            return AllLoadedTypes.First(x => x.Name == typeName);
        }

//        [StepArgumentTransformation("instance of (.*)")]
        public dynamic TransformToInstance(string typeName)
        {
            return Activator.CreateInstance(TransformToType(typeName));
        }
    }
}
