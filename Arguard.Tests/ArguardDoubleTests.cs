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
    public class ArguardDoubleTests
    {
        [Test]
        public void ArgumentZero_ZeroDouble()
        {
            double zeroDouble = 0.0;

            Assert.DoesNotThrow(
                () => Arguard.ArgumentZero(zeroDouble, nameof(zeroDouble)));
        }

        [TestCase(-1.1)]
        [TestCase(-10.1)]
        [TestCase(-100.1)]
        [TestCase(double.MinValue)]
        [TestCase(1.1)]
        [TestCase(10.1)]
        [TestCase(100.1)]
        [TestCase(double.MaxValue)]
        public void ArgumentZero_NonZeroDouble(double nonZeroDouble)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentZero(nonZeroDouble, nameof(nonZeroDouble)));

            StringAssert.Contains(nameof(nonZeroDouble), ex.ParamName);
            StringAssert.Contains($"{nameof(nonZeroDouble)} must be zero", ex.Message);
        }

        [TestCase(1.1)]
        [TestCase(10.1)]
        [TestCase(100.1)]
        [TestCase(double.MaxValue)]
        public void ArgumentPositive_PositiveDouble(double positiveDouble)
        {
            Assert.DoesNotThrow(
                () => Arguard.ArgumentPositive(positiveDouble, nameof(positiveDouble)));
        }

        [TestCase(0)]
        [TestCase(-1.1)]
        [TestCase(-10.1)]
        [TestCase(-100.1)]
        [TestCase(double.MinValue)]
        public void ArgumentPositive_NonPositiveDouble(double nonPositiveDouble)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentPositive(nonPositiveDouble, nameof(nonPositiveDouble)));

            StringAssert.Contains(nameof(nonPositiveDouble), ex.ParamName);
            StringAssert.Contains($"{nameof(nonPositiveDouble)} must be positive", ex.Message);
        }

        [TestCase(-1.1)]
        [TestCase(-10.1)]
        [TestCase(-100.1)]
        [TestCase(double.MinValue)]
        public void ArgumentNegative_NegativeDouble(double negativeDouble)
        {
            Assert.DoesNotThrow(
                () => Arguard.ArgumentNegative(negativeDouble, nameof(negativeDouble)));
        }

        [TestCase(0)]
        [TestCase(1.1)]
        [TestCase(10.1)]
        [TestCase(100.1)]
        [TestCase(double.MaxValue)]
        public void ArgumentNegative_NonNegativeDouble(double nonNegativeDouble)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNegative(nonNegativeDouble, nameof(nonNegativeDouble)));

            StringAssert.Contains(nameof(nonNegativeDouble), ex.ParamName);
            StringAssert.Contains($"{nameof(nonNegativeDouble)} must be negative", ex.Message);
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
        [TestCase(1.1)]
        [TestCase(10.1)]
        [TestCase(100.1)]
        [TestCase(double.MaxValue)]
        public void ArgumentNotNegative_NonNegativeDouble(double nonNegativeDouble)
        {
            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotNegative(nonNegativeDouble, nameof(nonNegativeDouble)));
        }

        [TestCase(0)]
        [TestCase(-1.1)]
        [TestCase(-10.1)]
        [TestCase(-100.1)]
        [TestCase(double.MinValue)]
        public void ArgumentNotPositive_NonPositiveDouble(double nonPositiveDouble)
        {
            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotPositive(nonPositiveDouble, nameof(nonPositiveDouble)));
        }

        [TestCase(1.1)]
        [TestCase(10.1)]
        [TestCase(100.1)]
        [TestCase(double.MaxValue)]
        public void ArgumentNotPositive_PositiveDouble(double positiveDouble)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotPositive(positiveDouble, nameof(positiveDouble)));

            StringAssert.Contains(nameof(positiveDouble), ex.ParamName);
            StringAssert.Contains($"{nameof(positiveDouble)} cannot be positive", ex.Message);
        }

        [TestCase(1.1)]
        [TestCase(10.1)]
        [TestCase(100.1)]
        [TestCase(double.MaxValue)]
        public void ArgumentGreaterThan_ValueGreaterThanThreshold(double value)
        {
            var thresholdValue = 1.0;

            Assert.DoesNotThrow(
                () => Arguard.ArgumentGreaterThan(value, nameof(value), thresholdValue));
        }

        [TestCase(1.0)]
        [TestCase(0.0)]
        [TestCase(-1.1)]
        [TestCase(-10.1)]
        [TestCase(-100.1)]
        [TestCase(double.MinValue)]
        public void ArgumentGreaterThan_ValueLessThanOrEqualThreshold(double value)
        {
            var thresholdValue = 1.0;

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentGreaterThan(value, nameof(value), thresholdValue));

            StringAssert.Contains(nameof(value), ex.ParamName);
            StringAssert.Contains($"{nameof(value)} must be greater than {thresholdValue}", ex.Message);
        }

        [TestCase(0.0)]
        [TestCase(-1.1)]
        [TestCase(-10.1)]
        [TestCase(-100.1)]
        [TestCase(double.MinValue)]
        public void ArgumentLessThan_ValueLessThanThreshold(double value)
        {
            var thresholdValue = 1.0;

            Assert.DoesNotThrow(
                () => Arguard.ArgumentLessThan(value, nameof(value), thresholdValue));
        }

        [TestCase(1.0)]
        [TestCase(10.1)]
        [TestCase(100.1)]
        [TestCase(double.MaxValue)]
        public void ArgumentLessThan_ValueGreaterThanThreshold(double value)
        {
            var thresholdValue = 1.0;

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentLessThan(value, nameof(value), thresholdValue));

            StringAssert.Contains(nameof(value), ex.ParamName);
            StringAssert.Contains($"{nameof(value)} must be less than {thresholdValue}", ex.Message);
        }
    }
}
