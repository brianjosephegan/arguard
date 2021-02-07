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
    public class ArguardLongTests
    {
        [Test]
        public void ArgumentZero_ZeroLong()
        {
            long zeroLong = 0;

            Assert.DoesNotThrow(
                () => Arguard.ArgumentZero(zeroLong, nameof(zeroLong)));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(long.MinValue)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(long.MaxValue)]
        public void ArgumentZero_NonZeroDouble(long nonZeroLong)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentZero(nonZeroLong, nameof(nonZeroLong)));

            StringAssert.Contains(nameof(nonZeroLong), ex.ParamName);
            StringAssert.Contains($"{nameof(nonZeroLong)} must be zero", ex.Message);
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(long.MaxValue)]
        public void ArgumentPositive_PositiveLong(long positiveLong)
        {
            Assert.DoesNotThrow(
                () => Arguard.ArgumentPositive(positiveLong, nameof(positiveLong)));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(long.MinValue)]
        public void ArgumentPositive_NonPositiveDouble(long nonPositiveLong)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentPositive(nonPositiveLong, nameof(nonPositiveLong)));

            StringAssert.Contains(nameof(nonPositiveLong), ex.ParamName);
            StringAssert.Contains($"{nameof(nonPositiveLong)} must be positive", ex.Message);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(long.MinValue)]
        public void ArgumentNegative_NegativeDouble(long negativeLong)
        {
            Assert.DoesNotThrow(
                () => Arguard.ArgumentNegative(negativeLong, nameof(negativeLong)));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(long.MaxValue)]
        public void ArgumentNegative_NonNegativeDouble(double nonNegativeLong)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNegative(nonNegativeLong, nameof(nonNegativeLong)));

            StringAssert.Contains(nameof(nonNegativeLong), ex.ParamName);
            StringAssert.Contains($"{nameof(nonNegativeLong)} must be negative", ex.Message);
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

        [TestCase(10)]
        [TestCase(100)]
        [TestCase(long.MaxValue)]
        public void ArgumentGreaterThan_ValueGreaterThanThreshold(long value)
        {
            var thresholdValue = 1;

            Assert.DoesNotThrow(
                () => Arguard.ArgumentGreaterThan(value, nameof(value), thresholdValue));
        }

        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(long.MinValue)]
        public void ArgumentGreaterThan_ValueLessThanOrEqualThreshold(long value)
        {
            var thresholdValue = 1;

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentGreaterThan(value, nameof(value), thresholdValue));

            StringAssert.Contains(nameof(value), ex.ParamName);
            StringAssert.Contains($"{nameof(value)} must be greater than {thresholdValue}", ex.Message);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        [TestCase(long.MinValue)]
        public void ArgumentLessThan_ValueLessThanThreshold(long value)
        {
            var thresholdValue = 1;

            Assert.DoesNotThrow(
                () => Arguard.ArgumentLessThan(value, nameof(value), thresholdValue));
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(long.MaxValue)]
        public void ArgumentLessThan_ValueGreaterThanThreshold(long value)
        {
            var thresholdValue = 1;

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentLessThan(value, nameof(value), thresholdValue));

            StringAssert.Contains(nameof(value), ex.ParamName);
            StringAssert.Contains($"{nameof(value)} must be less than {thresholdValue}", ex.Message);
        }
    }
}
