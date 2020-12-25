using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guard;
using NUnit.Framework;

namespace Guard.Tests
{
    /// <summary>
    /// Unit tests for <see cref="Guard"/> class.
    /// </summary>
    [TestFixture]
    public class GuardTests
    {
        [Test]
        public void ArgumentNotNull_NullArgument()
        {
            string invalidString = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => Guard.ArgumentNotNull(invalidString, nameof(invalidString)));

            StringAssert.Contains(nameof(invalidString), ex.ParamName);
            StringAssert.Contains($"{nameof(invalidString)} cannot be null", ex.Message);
        }

        [Test]
        public void ArgumentNotNull_NotNullArgument()
        {
            string validString = "This string is not null.";

            Assert.DoesNotThrow(
                () => Guard.ArgumentNotNull(validString, nameof(validString)));
        }
    }
}
