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
    }
}
