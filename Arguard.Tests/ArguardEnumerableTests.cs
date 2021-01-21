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
        public void ArgumentEmpty_EmptyCollection()
        {
            IEnumerable<object> emptyCollection = Enumerable.Empty<object>();

            Assert.DoesNotThrow(
                () => Arguard.ArgumentEmpty(emptyCollection, nameof(emptyCollection)));
        }

        [Test]
        public void ArgumentEmpty_NonEmptyCollection()
        {
            IEnumerable<object> nonEmptyCollection = new List<object>() { new object() };

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentEmpty(nonEmptyCollection, nameof(nonEmptyCollection)));

            StringAssert.Contains(nameof(nonEmptyCollection), ex.ParamName);
            StringAssert.Contains($"{nameof(nonEmptyCollection)} must be empty", ex.Message);
        }

        [Test]
        public void ArgumentNotEmpty_EmptyCollection()
        {
            IEnumerable<object> emptyCollection = Enumerable.Empty<object>();

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotEmpty(emptyCollection, nameof(emptyCollection)));

            StringAssert.Contains(nameof(emptyCollection), ex.ParamName);
            StringAssert.Contains($"{nameof(emptyCollection)} cannot be empty", ex.Message);
        }

        [Test]
        public void ArgumentNotEmpty_NonEmptyCollection()
        {
            IEnumerable<object> nonEmptyCollection = new List<object>() { new object() };

            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotEmpty(nonEmptyCollection, nameof(nonEmptyCollection)));
        }

        [Test]
        public void ArgumentCount_CountMatches()
        {
            IEnumerable<object> collection = new List<object>() { new object(), new object(), new object() };
            var expectedNumberOfElements = collection.Count();

            Assert.DoesNotThrow(
                () => Arguard.ArgumentCount(collection, nameof(collection), expectedNumberOfElements));
        }

        [Test]
        public void ArgumentCount_CountDoesNotMatch()
        {
            IEnumerable<object> collection = new List<object>() { new object(), new object(), new object() };
            var expectedNumberOfElements = collection.Count() + 1;


            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentCount(collection, nameof(collection), expectedNumberOfElements));

            StringAssert.Contains(nameof(collection), ex.ParamName);
            StringAssert.Contains($"{nameof(collection)} must contain {expectedNumberOfElements} elements", ex.Message);
        }

        [Test]
        public void ArgumentNoNulls_CollectionWithNoNulls()
        {
            IEnumerable<object> collectionWithNoNulls = new List<object>() { new object(), new object(), new object() };

            Assert.DoesNotThrow(
                () => Arguard.ArgumentNoNulls(collectionWithNoNulls, nameof(collectionWithNoNulls)));
        }

        [Test]
        public void ArgumentNoNulls_CollectionWithNulls()
        {
            IEnumerable<object> collectionWithNulls = new List<object>() { new object(), null, new object() };

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNoNulls(collectionWithNulls, nameof(collectionWithNulls)));

            StringAssert.Contains(nameof(collectionWithNulls), ex.ParamName);
            StringAssert.Contains($"{nameof(collectionWithNulls)} cannot contain nulls", ex.Message);
        }
    }
}
