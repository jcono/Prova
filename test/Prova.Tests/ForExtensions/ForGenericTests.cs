using System;
using NUnit.Framework;
using Prova.Extensions;

namespace Prova.Tests.ForExtensions
{
    [TestFixture]
    public class ForGenericTests
    {
        [Test]
        public void IsNothingShouldReturnFalseForAValueTypeThatIsNotEmpty()
        {
            var theObject = new DateTime(1984, 1, 1);

            Assert.That(theObject.IsNothing(), Is.False);
        }

        [Test]
        public void IsNothingShouldReturnForFalseAReferenceTypeThatIsNotNull()
        {
            var theObject = new Exception();

            Assert.That(theObject.IsNothing(), Is.False);
        }

        [Test]
        public void IsNothingShouldReturnTrueForAReferenceTypeThatIsNull()
        {
            const Exception theObject = null;

            Assert.That(theObject.IsNothing());
        }

        [Test]
        public void IsNothingShouldReturnTrueForAValueTypeThatIsEmpty()
        {
            var theObject = new DateTime();

            Assert.That(theObject.IsNothing());
        }
    }
}
