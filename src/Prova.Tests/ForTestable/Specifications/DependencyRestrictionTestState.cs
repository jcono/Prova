using System;
using NUnit.Framework;
using Prova.Extensions;
using Prova.Tests.ForTestable.Types;

namespace Prova.Tests.ForTestable.Specifications
{
    public class DependencyRestrictionTestState
    {
        private Testable _testable;
        private Exception _exception;
        private Type _expectedExceptionType;

        public void HaveATestableObject()
        {
            _testable = new Testable(typeof(HasSingleDependency));
        }

        public Action TellTheObjectToUse<T>(T dependency)
        {
            return () =>
            {
                Action action = () => _testable.With(dependency);
                _exception = action.GetException();
            };
        }

        public Action LookForAnExceptionWith(Type expectedExceptionType)
        {
            return () => _expectedExceptionType = expectedExceptionType;
        }

        public void ShouldHaveSeenThatException()
        {
            Assert.That(_exception, Is.InstanceOf(_expectedExceptionType));
        }
    }
}