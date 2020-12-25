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
            object nullObject = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => Guard.ArgumentNotNull(nullObject, nameof(nullObject)));

            StringAssert.Contains(nameof(nullObject), ex.ParamName);
            StringAssert.Contains($"{nameof(nullObject)} cannot be null", ex.Message);
        }

        [Test]
        public void ArgumentNotNull_NotNullArgument()
        {
            object notNullObject = new object();

            Assert.DoesNotThrow(
                () => Guard.ArgumentNotNull(notNullObject, nameof(notNullObject)));
        }

        [Test]
        public void ArgumentNotNullOrEmptyString_NullString()
        {
            string nullString = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => Guard.ArgumentNotNullOrEmptyString(nullString, nameof(nullString)));

            StringAssert.Contains(nameof(nullString), ex.ParamName);
            StringAssert.Contains($"{nameof(nullString)} cannot be null", ex.Message);
        }

        [Test]
        public void ArgumentNotNullOrEmptyString_EmptyString()
        {
            string emptyString = string.Empty;

            var ex = Assert.Throws<ArgumentException>(
                () => Guard.ArgumentNotNullOrEmptyString(emptyString, nameof(emptyString)));

            StringAssert.Contains(nameof(emptyString), ex.ParamName);
            StringAssert.Contains($"{nameof(emptyString)} cannot be empty", ex.Message);
        }

        [Test]
        public void ArgumentNotNullOrEmptyString_ValidString()
        {
            string validString = "This is a valid string.";

            Assert.DoesNotThrow(
                () => Guard.ArgumentNotNullOrEmptyString(validString, nameof(validString)));
        }

        [Test]
        public void GuidNotEmpty_EmptyGuid()
        {
            Guid emptyGuid = Guid.Empty;

            var ex = Assert.Throws<ArgumentException>(
                () => Guard.GuidNotEmpty(emptyGuid, nameof(emptyGuid)));

            StringAssert.Contains(nameof(emptyGuid), ex.ParamName);
            StringAssert.Contains($"{nameof(emptyGuid)} cannot be empty", ex.Message);
        }

        [Test]
        public void GuidNotEmpty_ValidGuid()
        {
            Guid validGuid = Guid.NewGuid();

            Assert.DoesNotThrow(
                () => Guard.GuidNotEmpty(validGuid, nameof(validGuid)));
        }
    }
}
