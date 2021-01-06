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
        public void ArgumentEmptyString_EmptyString()
        {
            string emptyString = string.Empty;

            var ex = Assert.Throws<ArgumentException>(
                () => Guard.ArgumentNotEmptyString(emptyString, nameof(emptyString)));

            StringAssert.Contains(nameof(emptyString), ex.ParamName);
            StringAssert.Contains($"{nameof(emptyString)} cannot be empty", ex.Message);
        }

        [Test]
        public void ArgumentNotEmptyString_ValidString()
        {
            string validString = "This is a valid string.";

            Assert.DoesNotThrow(
                () => Guard.ArgumentNotEmptyString(validString, nameof(validString)));
        }

        [Test]
        public void ArgumentNotEmptyCollection_EmptyCollection()
        {
            IEnumerable<object> emptyCollection = Enumerable.Empty<object>();

            var ex = Assert.Throws<ArgumentException>(
                () => Guard.ArgumentNotEmptyCollection(emptyCollection, nameof(emptyCollection)));

            StringAssert.Contains(nameof(emptyCollection), ex.ParamName);
            StringAssert.Contains($"{nameof(emptyCollection)} cannot be empty", ex.Message);
        }

        [Test]
        public void ArgumentNotEmptyCollection_ValidCollection()
        {
            IEnumerable<object> emptyCollection = new List<object>() { new object() };

            Assert.DoesNotThrow(
                () => Guard.ArgumentNotEmptyCollection(emptyCollection, nameof(emptyCollection)));
        }

        [Test]
        public void ArgumentNotEmptyGuid_EmptyGuid()
        {
            Guid emptyGuid = Guid.Empty;

            var ex = Assert.Throws<ArgumentException>(
                () => Guard.ArgumentNotEmptyGuid(emptyGuid, nameof(emptyGuid)));

            StringAssert.Contains(nameof(emptyGuid), ex.ParamName);
            StringAssert.Contains($"{nameof(emptyGuid)} cannot be empty", ex.Message);
        }

        [Test]
        public void ArgumentNotEmptyGuid_ValidGuid()
        {
            Guid validGuid = Guid.NewGuid();

            Assert.DoesNotThrow(
                () => Guard.ArgumentNotEmptyGuid(validGuid, nameof(validGuid)));
        }
    }
}
