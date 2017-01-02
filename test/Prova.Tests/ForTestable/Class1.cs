﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Prova.Tests.ForTestable
{
    class Class1
    {
        [Test]
        public void Blah()
        {
            var t = new TestableObject<MyObject>();

            t.With(x => x.Name).SetTo("my name");

            Assert.That(t.Create().Name, Is.EqualTo("my name"));
        }
    }

    internal class MyObject
    {
        public string Name { get; set; }
    }

    internal class TestableObject<T> where T : new()
    {
        private ExpressionWrapper<T> _expressionWrapper;

        public ExpressionWrapper<T> With(Expression<Func<T, dynamic>> expression)
        {
            _expressionWrapper = new ExpressionWrapper<T>(expression);
            return _expressionWrapper;
        }

        public T Create()
        {
            var foo = new T();
            _expressionWrapper.ApplyTo(foo);
            return foo;
        }
    }

    internal class ExpressionWrapper<T>
    {
        private readonly Expression<Func<T, dynamic>> _expression;
        private dynamic _value;

        public ExpressionWrapper(Expression<Func<T, dynamic>> expression)
        {
            _expression = expression;
        }

        public void SetTo(dynamic value)
        {
            _value = value;
        }

        public void ApplyTo(dynamic instance)
        {
            var memberExpression = _expression.Body as MemberExpression;

            var propertyInfo = memberExpression.Member as PropertyInfo;

            propertyInfo.SetValue(instance, _value);
        }
    }
}
