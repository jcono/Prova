using NUnit.Framework;
using Prova.Extensions;

namespace Prova.Tests.ForExtensions
{
    [TestFixture]
    public class ForIEnumerableTests
    {
        [Test]
        public void AreUniqueShouldReturnFalseForAUniqueArray()
        {
            var strings = new[] { "one", "two", "three" };

            var result = strings.AreUnique();

            Assert.That(result, Is.True);
        }

        [Test]
        public void AreUniqueShouldReturnTrueForNullEnumerable()
        {
            object[] objects = null;

            var result = objects.AreUnique();

            Assert.That(result, Is.True);
        }

        [Test]
        public void AreUniqueShouldReturnTrueWithRepeatedItem()
        {
            var strings = new[] { "one", "one", "two" };

            var result = strings.AreUnique();

            Assert.That(result, Is.False);
        }

        [Test]
        public void HasCountOfShouldReturnFalseForIncorrectCount()
        {
            var strings = new[] { "one", "two", "three" };

            var result = strings.HasCountOf(4);

            Assert.That(result, Is.False);
        }

        [Test]
        public void HasCountOfShouldReturnFalseForNullEnumerable()
        {
            object[] objects = null;

            var result = objects.HasCountOf(0);

            Assert.That(result, Is.False);
        }

        [Test]
        public void HasCountOfShouldReturnTrueForCorrectCount()
        {
            var strings = new[] { "one", "two", "three" };

            var result = strings.HasCountOf(3);

            Assert.That(result, Is.True);
        }
    }
}
