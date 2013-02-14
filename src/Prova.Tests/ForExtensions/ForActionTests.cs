using System;
using NUnit.Framework;
using Prova.Extensions;

namespace Prova.Tests.ForExtensions
{
    [TestFixture]
    public class ForActionTests
    {
        [Test]
        public void GetExceptionShouldReturnAnExceptionThatIsThrownByAction()
        {
            var expectedException = new ArithmeticException();
            Action action = () => { throw expectedException; };

            var exception = action.GetException();

            Assert.That(exception, Is.EqualTo(expectedException));
        }

        [Test]
        public void GetExceptionShouldReturnNullIfActionIsNull()
        {
            const Action action = null;

            var exception = action.GetException();

            Assert.That(exception, Is.Null);
        }

        [Test]
        public void GetExceptionShouldReturnNullIfNoExceptionIsThrownByAction()
        {
            Action action = () => { };

            var exception = action.GetException();

            Assert.That(exception, Is.Null);
        }
    }
}
