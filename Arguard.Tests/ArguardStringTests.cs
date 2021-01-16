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
        public void ArgumentEmptyString_EmptyString()
        {
            string emptyString = string.Empty;

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotEmptyString(emptyString, nameof(emptyString)));

            StringAssert.Contains(nameof(emptyString), ex.ParamName);
            StringAssert.Contains($"{nameof(emptyString)} cannot be empty", ex.Message);
        }

        [Test]
        public void ArgumentNotEmptyString_ValidString()
        {
            string validString = "This is a valid string.";

            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotEmptyString(validString, nameof(validString)));
        }
    }
}
