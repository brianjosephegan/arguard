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
    public class ArguardEnumerableTests
    {
        [Test]
        public void ArgumentNotEmptyCollection_EmptyCollection()
        {
            IEnumerable<object> emptyCollection = Enumerable.Empty<object>();

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotEmptyCollection(emptyCollection, nameof(emptyCollection)));

            StringAssert.Contains(nameof(emptyCollection), ex.ParamName);
            StringAssert.Contains($"{nameof(emptyCollection)} cannot be empty", ex.Message);
        }

        [Test]
        public void ArgumentNotEmptyCollection_ValidCollection()
        {
            IEnumerable<object> emptyCollection = new List<object>() { new object() };

            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotEmptyCollection(emptyCollection, nameof(emptyCollection)));
        }
    }
}
