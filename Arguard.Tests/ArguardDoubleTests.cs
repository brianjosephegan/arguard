﻿using System;
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
    }
}
