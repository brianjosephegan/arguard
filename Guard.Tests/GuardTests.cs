using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guard;
using NUnit.Framework;

namespace Guard.Tests
{
    /// <summary>
    /// Unit tests for <see cref="Guard"/> class.
    /// </summary>
    [TestFixture]
    public class GuardTests
    {
        [Test]
        public void ArgumentNotNull_NullArgument()
        {
            object nullObject = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => Guard.ArgumentNotNull(nullObject, nameof(nullObject)));

            StringAssert.Contains(nameof(nullObject), ex.ParamName);
            StringAssert.Contains($"{nameof(nullObject)} cannot be null", ex.Message);
        }

        [Test]
        public void ArgumentNotNull_NotNullArgument()
        {
            object notNullObject = new object();

            Assert.DoesNotThrow(
                () => Guard.ArgumentNotNull(notNullObject, nameof(notNullObject)));
        }

        [Test]
        public void ArgumentEmptyString_EmptyString()
        {
            string emptyString = string.Empty;

            var ex = Assert.Throws<ArgumentException>(
                () => Guard.ArgumentNotEmptyString(emptyString, nameof(emptyString)));

            StringAssert.Contains(nameof(emptyString), ex.ParamName);
            StringAssert.Contains($"{nameof(emptyString)} cannot be empty", ex.Message);
        }

        [Test]
        public void ArgumentNotEmptyString_ValidString()
        {
            string validString = "This is a valid string.";

            Assert.DoesNotThrow(
                () => Guard.ArgumentNotEmptyString(validString, nameof(validString)));
        }

        [Test]
        public void ArgumentNotEmptyCollection_EmptyCollection()
        {
            IEnumerable<object> emptyCollection = Enumerable.Empty<object>();

            var ex = Assert.Throws<ArgumentException>(
                () => Guard.ArgumentNotEmptyCollection(emptyCollection, nameof(emptyCollection)));

            StringAssert.Contains(nameof(emptyCollection), ex.ParamName);
            StringAssert.Contains($"{nameof(emptyCollection)} cannot be empty", ex.Message);
        }

        [Test]
        public void ArgumentNotEmptyCollection_ValidCollection()
        {
            IEnumerable<object> emptyCollection = new List<object>() { new object() };

            Assert.DoesNotThrow(
                () => Guard.ArgumentNotEmptyCollection(emptyCollection, nameof(emptyCollection)));
        }

        [Test]
        public void ArgumentNotEmptyGuid_EmptyGuid()
        {
            Guid emptyGuid = Guid.Empty;

            var ex = Assert.Throws<ArgumentException>(
                () => Guard.ArgumentNotEmptyGuid(emptyGuid, nameof(emptyGuid)));

            StringAssert.Contains(nameof(emptyGuid), ex.ParamName);
            StringAssert.Contains($"{nameof(emptyGuid)} cannot be empty", ex.Message);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(int.MinValue)]
        public void ArgumentNotNegative_NegativeInteger(int negativeInteger)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Guard.ArgumentNotNegative(negativeInteger, nameof(negativeInteger)));

            StringAssert.Contains(nameof(negativeInteger), ex.ParamName);
            StringAssert.Contains($"{nameof(negativeInteger)} cannot be negative", ex.Message);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(int.MaxValue)]
        public void ArgumentNotNegative_NonNegativeInteger(int nonNegativeInteger)
        {
            Assert.DoesNotThrow(
                () => Guard.ArgumentNotNegative(nonNegativeInteger, nameof(nonNegativeInteger)));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(long.MinValue)]
        public void ArgumentNotNegative_NegativeLong(long negativeLong)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Guard.ArgumentNotNegative(negativeLong, nameof(negativeLong)));

            StringAssert.Contains(nameof(negativeLong), ex.ParamName);
            StringAssert.Contains($"{nameof(negativeLong)} cannot be negative", ex.Message);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(long.MaxValue)]
        public void ArgumentNotNegative_NonNegativeLong(long nonNegativeLong)
        {
            Assert.DoesNotThrow(
                () => Guard.ArgumentNotNegative(nonNegativeLong, nameof(nonNegativeLong)));
        }

        [TestCase(-1.1f)]
        [TestCase(-10.1f)]
        [TestCase(-100.1f)]
        [TestCase(float.MinValue)]
        public void ArgumentNotNegative_NegativeFloat(float negativeFloat)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Guard.ArgumentNotNegative(negativeFloat, nameof(negativeFloat)));

            StringAssert.Contains(nameof(negativeFloat), ex.ParamName);
            StringAssert.Contains($"{nameof(negativeFloat)} cannot be negative", ex.Message);
        }

        [TestCase(0f)]
        [TestCase(1f)]
        [TestCase(10f)]
        [TestCase(100f)]
        [TestCase(float.MaxValue)]
        public void ArgumentNotNegative_NonNegativeFloat(float nonNegativeFloat)
        {
            Assert.DoesNotThrow(
                () => Guard.ArgumentNotNegative(nonNegativeFloat, nameof(nonNegativeFloat)));
        }

        [TestCase(-1.1)]
        [TestCase(-10.1)]
        [TestCase(-100.1)]
        [TestCase(double.MinValue)]
        public void ArgumentNotNegative_NegativeDouble(double negativeDouble)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Guard.ArgumentNotNegative(negativeDouble, nameof(negativeDouble)));

            StringAssert.Contains(nameof(negativeDouble), ex.ParamName);
            StringAssert.Contains($"{nameof(negativeDouble)} cannot be negative", ex.Message);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(double.MaxValue)]
        public void ArgumentNotNegative_NonNegativeDouble(double nonNegativeDouble)
        {
            Assert.DoesNotThrow(
                () => Guard.ArgumentNotNegative(nonNegativeDouble, nameof(nonNegativeDouble)));
        }

        [Test]
        public void ArgumentNotEmptyGuid_ValidGuid()
        {
            Guid validGuid = Guid.NewGuid();

            Assert.DoesNotThrow(
                () => Guard.ArgumentNotEmptyGuid(validGuid, nameof(validGuid)));
        }
    }
}
