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
    public class ArguardTypeTests
    {
        [Test]
        public void ArgumentType_MatchingType()
        {
            string stringType = string.Empty;

            Assert.DoesNotThrow(
                () => Arguard.ArgumentType(stringType, nameof(stringType), typeof(string)));
        }

        [Test]
        public void ArgumentType_NotMatchingType()
        {
            string stringType = string.Empty;

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentType(stringType, nameof(stringType), typeof(StringBuilder)));

            StringAssert.Contains(nameof(stringType), ex.ParamName);
            StringAssert.Contains($"{nameof(stringType)} must be of type {typeof(StringBuilder)}", ex.Message);
        }

        [Test]
        public void ArgumentNotType_NotMatchingType()
        {
            string stringType = string.Empty;

            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotType(stringType, nameof(stringType), typeof(StringBuilder)));
        }

        [Test]
        public void ArgumentNotType_MatchingType()
        {
            string stringType = string.Empty;

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotType(stringType, nameof(stringType), typeof(string)));

            StringAssert.Contains(nameof(stringType), ex.ParamName);
            StringAssert.Contains($"{nameof(stringType)} cannot be of type {typeof(string)}", ex.Message);
        }
    }
}
