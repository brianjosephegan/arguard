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
    public class ArguardBooleanTests
    {
        [Test]
        public void ArgumentTrue_TrueValue()
        {
            bool trueArgument = true;

            Assert.DoesNotThrow(
                () => Arguard.ArgumentTrue(trueArgument, nameof(trueArgument)));
        }

        [Test]
        public void ArgumentTrue_FalseValue()
        {
            bool falseArgument = false;

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentTrue(falseArgument, nameof(falseArgument)));

            StringAssert.Contains(nameof(falseArgument), ex.ParamName);
            StringAssert.Contains($"{nameof(falseArgument)} must be true", ex.Message);
        }

        [Test]
        public void ArgumentFalse_FalseValue()
        {
            bool falseArgument = false;

            Assert.DoesNotThrow(
                () => Arguard.ArgumentFalse(falseArgument, nameof(falseArgument)));
        }

        [Test]
        public void ArgumentFalse_TrueValue()
        {
            bool trueArgument = true;

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentFalse(trueArgument, nameof(trueArgument)));

            StringAssert.Contains(nameof(trueArgument), ex.ParamName);
            StringAssert.Contains($"{nameof(trueArgument)} must be false", ex.Message);
        }
    }
}