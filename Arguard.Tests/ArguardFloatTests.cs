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
    public class ArguardFloatTests
    {
        [Test]
        public void ArgumentZero_ZeroFloat()
        {
            float zeroFloat = 0.0f;

            Assert.DoesNotThrow(
                () => Arguard.ArgumentZero(zeroFloat, nameof(zeroFloat)));
        }

        [TestCase(-1.1f)]
        [TestCase(-10.1f)]
        [TestCase(-100.1f)]
        [TestCase(float.MinValue)]
        [TestCase(1.1f)]
        [TestCase(10.1f)]
        [TestCase(100.1f)]
        [TestCase(float.MaxValue)]
        public void ArgumentZero_NonZeroFloat(float nonZeroFloat)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentZero(nonZeroFloat, nameof(nonZeroFloat)));

            StringAssert.Contains(nameof(nonZeroFloat), ex.ParamName);
            StringAssert.Contains($"{nameof(nonZeroFloat)} must be zero", ex.Message);
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
        [TestCase(1.1f)]
        [TestCase(10.1f)]
        [TestCase(100.1f)]
        [TestCase(float.MaxValue)]
        public void ArgumentNotNegative_NonNegativeFloat(float nonNegativeFloat)
        {
            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotNegative(nonNegativeFloat, nameof(nonNegativeFloat)));
        }

        [TestCase(0f)]
        [TestCase(-1.1f)]
        [TestCase(-10.1f)]
        [TestCase(-100.1f)]
        [TestCase(float.MinValue)]
        public void ArgumentNotPositive_NonPositiveDouble(float nonPositiveFloat)
        {
            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotPositive(nonPositiveFloat, nameof(nonPositiveFloat)));
        }

        [TestCase(1.1f)]
        [TestCase(10.1f)]
        [TestCase(100.1f)]
        [TestCase(float.MaxValue)]
        public void ArgumentNotPositive_PositiveDouble(float positiveFloat)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotPositive(positiveFloat, nameof(positiveFloat)));

            StringAssert.Contains(nameof(positiveFloat), ex.ParamName);
            StringAssert.Contains($"{nameof(positiveFloat)} cannot be positive", ex.Message);
        }
    }
}
