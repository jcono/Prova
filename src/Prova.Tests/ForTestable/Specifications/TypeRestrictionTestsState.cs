using System;
using NUnit.Framework;
using Prova.Extensions;

namespace Prova.Tests.ForTestable.Specifications
{
    public class TypeRestrictionTestsState
    {
        private Exception _exception;
        private Type _expectedExceptionType;
        private object _instance;

        public Action TryAndCreateATestableWith(Type type)
        {
            return () =>
            {
                Action action = () => _instance = new Testable(type).Create();
                _exception = action.GetException();
            };
        }

        public void ShouldHaveSeenThatException()
        {
            Assert.That(_exception, Is.InstanceOf(_expectedExceptionType));
        }

        public void LookForAn<TException>() where TException : Exception
        {
            _expectedExceptionType = typeof(TException);
        }

        public void ShouldNotHaveAnException()
        {
            Assert.That(_exception, Is.Null);
        }

        public void ShouldHaveAnInstanceOf<T>()
        {
            Assert.That((T)_instance, Is.Not.Null);
        }
    }
}