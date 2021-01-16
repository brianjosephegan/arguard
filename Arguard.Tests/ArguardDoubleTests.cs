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
    }
}
