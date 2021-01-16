using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Arguard.Tests
{
    /// <summary>
    /// Unit tests for <see cref="Arguard"/> class.
    /// </summary>
    [TestFixture]
    public class ArguardTests
    {
        [Test]
        public void ArgumentNotNull_NullArgument()
        {
            object nullObject = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => Arguard.ArgumentNotNull(nullObject, nameof(nullObject)));

            StringAssert.Contains(nameof(nullObject), ex.ParamName);
            StringAssert.Contains($"{nameof(nullObject)} cannot be null", ex.Message);
        }

        [Test]
        public void ArgumentNotNull_NotNullArgument()
        {
            object notNullObject = new object();

            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotNull(notNullObject, nameof(notNullObject)));
        }

        [Test]
        public void ArgumentEmptyString_EmptyString()
        {
            string emptyString = string.Empty;

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotEmptyString(emptyString, nameof(emptyString)));

            StringAssert.Contains(nameof(emptyString), ex.ParamName);
            StringAssert.Contains($"{nameof(emptyString)} cannot be empty", ex.Message);
        }

        [Test]
        public void ArgumentNotEmptyString_ValidString()
        {
            string validString = "This is a valid string.";

            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotEmptyString(validString, nameof(validString)));
        }

        [Test]
        public void ArgumentNotEmptyCollection_EmptyCollection()
        {
            IEnumerable<object> emptyCollection = Enumerable.Empty<object>();

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotEmptyCollection(emptyCollection, nameof(emptyCollection)));

            StringAssert.Contains(nameof(emptyCollection), ex.ParamName);
            StringAssert.Contains($"{nameof(emptyCollection)} cannot be empty", ex.Message);
        }

        [Test]
        public void ArgumentNotEmptyCollection_ValidCollection()
        {
            IEnumerable<object> emptyCollection = new List<object>() { new object() };

            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotEmptyCollection(emptyCollection, nameof(emptyCollection)));
        }

        [Test]
        public void ArgumentNotEmptyGuid_EmptyGuid()
        {
            Guid emptyGuid = Guid.Empty;

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotEmptyGuid(emptyGuid, nameof(emptyGuid)));

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
                () => Arguard.ArgumentNotNegative(negativeInteger, nameof(negativeInteger)));

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
                () => Arguard.ArgumentNotNegative(nonNegativeInteger, nameof(nonNegativeInteger)));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(long.MinValue)]
        public void ArgumentNotNegative_NegativeLong(long negativeLong)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotNegative(negativeLong, nameof(negativeLong)));

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
                () => Arguard.ArgumentNotNegative(nonNegativeLong, nameof(nonNegativeLong)));
        }

        [TestCase(-1.1f)]
        [TestCase(-10.1f)]
        [TestCase(-100.1f)]
        [TestCase(float.MinValue)]
        public void ArgumentNotNegative_NegativeFloat(float negativeFloat)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotNegative(negativeFloat, nameof(negativeFloat)));

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
                () => Arguard.ArgumentNotNegative(nonNegativeFloat, nameof(nonNegativeFloat)));
        }

        [TestCase(-1.1)]
        [TestCase(-10.1)]
        [TestCase(-100.1)]
        [TestCase(double.MinValue)]
        public void ArgumentNotNegative_NegativeDouble(double negativeDouble)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotNegative(negativeDouble, nameof(negativeDouble)));

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
                () => Arguard.ArgumentNotNegative(nonNegativeDouble, nameof(nonNegativeDouble)));
        }

        [Test]
        public void ArgumentNotZero_ZeroInteger()
        {
            int zeroInteger = 0;

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotZero(zeroInteger, nameof(zeroInteger)));

            StringAssert.Contains(nameof(zeroInteger), ex.ParamName);
            StringAssert.Contains($"{nameof(zeroInteger)} cannot be zero", ex.Message);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(int.MinValue)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(int.MaxValue)]
        public void ArgumentNotZero_NonZeroLong(int nonZeroInteger)
        {
            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotZero(nonZeroInteger, nameof(nonZeroInteger)));
        }

        [Test]
        public void ArgumentNotZero_ZeroLong()
        {
            long zeroLong = 0;

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotZero(zeroLong, nameof(zeroLong)));

            StringAssert.Contains(nameof(zeroLong), ex.ParamName);
            StringAssert.Contains($"{nameof(zeroLong)} cannot be zero", ex.Message);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(long.MinValue)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(long.MaxValue)]
        public void ArgumentNotZero_NonZeroLong(long nonZeroLong)
        {
            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotZero(nonZeroLong, nameof(nonZeroLong)));
        }

        [Test]
        public void ArgumentNotZero_ZeroFloat()
        {
            float zeroFloat = 0.0f;

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotZero(zeroFloat, nameof(zeroFloat)));

            StringAssert.Contains(nameof(zeroFloat), ex.ParamName);
            StringAssert.Contains($"{nameof(zeroFloat)} cannot be zero", ex.Message);
        }

        [TestCase(-1.1f)]
        [TestCase(-10.1f)]
        [TestCase(-100.1f)]
        [TestCase(float.MinValue)]
        [TestCase(1.1f)]
        [TestCase(10.1f)]
        [TestCase(100.1f)]
        [TestCase(float.MaxValue)]
        public void ArgumentNotZero_NonZeroFloat(float nonZeroFloat)
        {
            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotZero(nonZeroFloat, nameof(nonZeroFloat)));
        }

        [Test]
        public void ArgumentNotZero_ZeroDouble()
        {
            double zeroDouble = 0.0;

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotZero(zeroDouble, nameof(zeroDouble)));

            StringAssert.Contains(nameof(zeroDouble), ex.ParamName);
            StringAssert.Contains($"{nameof(zeroDouble)} cannot be zero", ex.Message);
        }

        [TestCase(-1.1)]
        [TestCase(-10.1)]
        [TestCase(-100.1)]
        [TestCase(double.MinValue)]
        [TestCase(1.1)]
        [TestCase(10.1)]
        [TestCase(100.1)]
        [TestCase(double.MaxValue)]
        public void ArgumentNotZero_NonZeroDouble(double nonZeroDouble)
        {
            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotZero(nonZeroDouble, nameof(nonZeroDouble)));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(int.MinValue)]
        public void ArgumentNotPositive_NonPositiveInteger(int nonPositiveInteger)
        {
            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotPositive(nonPositiveInteger, nameof(nonPositiveInteger)));
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(int.MaxValue)]
        public void ArgumentNotPositive_PositiveInteger(int positiveInteger)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotPositive(positiveInteger, nameof(positiveInteger)));

            StringAssert.Contains(nameof(positiveInteger), ex.ParamName);
            StringAssert.Contains($"{nameof(positiveInteger)} cannot be positive", ex.Message);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(long.MinValue)]
        public void ArgumentNotPositive_NonPositiveLong(long nonPositiveLong)
        {
            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotPositive(nonPositiveLong, nameof(nonPositiveLong)));
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(long.MaxValue)]
        public void ArgumentNotPositive_PositiveLong(long positiveLong)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotPositive(positiveLong, nameof(positiveLong)));

            StringAssert.Contains(nameof(positiveLong), ex.ParamName);
            StringAssert.Contains($"{nameof(positiveLong)} cannot be positive", ex.Message);
        }

        [Test]
        public void ArgumentNotEmptyGuid_ValidGuid()
        {
            Guid validGuid = Guid.NewGuid();

            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotEmptyGuid(validGuid, nameof(validGuid)));
        }
    }
}
