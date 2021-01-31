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
    public class ArguardStringTests
    {
        [Test]
        public void ArgumentEmpty_EmptyString()
        {
            string emptyString = string.Empty;

            Assert.DoesNotThrow(
                () => Arguard.ArgumentEmpty(emptyString, nameof(emptyString)));
        }

        [Test]
        public void ArgumentEmpty_NonEmptyString()
        {
            string nonEmptyString = "This is not an empty string.";

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentEmpty(nonEmptyString, nameof(nonEmptyString)));

            StringAssert.Contains(nameof(nonEmptyString), ex.ParamName);
            StringAssert.Contains($"{nameof(nonEmptyString)} must be empty", ex.Message);
        }

        [Test]
        public void ArgumentNotEmpty_EmptyString()
        {
            string emptyString = string.Empty;

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotEmpty(emptyString, nameof(emptyString)));

            StringAssert.Contains(nameof(emptyString), ex.ParamName);
            StringAssert.Contains($"{nameof(emptyString)} cannot be empty", ex.Message);
        }

        [Test]
        public void ArgumentNotEmpty_ValidString()
        {
            string nonEmptyString = "This is not an empty string.";

            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotEmpty(nonEmptyString, nameof(nonEmptyString)));
        }

        [Test]
        public void ArgumentLength_ExpectedLengthMatched()
        {
            string hello = "hello";

            Assert.DoesNotThrow(
                () => Arguard.ArgumentLength(hello, nameof(hello), 5));
        }

        [Test]
        public void ArgumentLength_ExpectedLengthNotMatched()
        {
            string hello = "hello";

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentLength(hello, nameof(hello), 2));

            StringAssert.Contains(nameof(hello), ex.ParamName);
            StringAssert.Contains($"{nameof(hello)} must be of length 2", ex.Message);
        }

        [Test]
        public void ArgumentNotLength_ExpectedLengthMatched()
        {
            string hello = "hello";

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotLength(hello, nameof(hello), 5));

            StringAssert.Contains(nameof(hello), ex.ParamName);
            StringAssert.Contains($"{nameof(hello)} cannot be of length 5", ex.Message);
        }

        [Test]
        public void ArgumentNotLength_ExpectedLengthNotMatched()
        {
            string hello = "hello";

            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotLength(hello, nameof(hello), 2));
        }
    }
}
