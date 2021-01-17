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
        public void ArgumentZero_NonZeroDouble(double nonZeroLong)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentZero(nonZeroLong, nameof(nonZeroLong)));

            StringAssert.Contains(nameof(nonZeroLong), ex.ParamName);
            StringAssert.Contains($"{nameof(nonZeroLong)} must be zero", ex.Message);
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
    }
}
