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
    public class ArguardNullTests
    {
        [Test]
        public void ArgumentNull_NullArgument()
        {
            object nullObject = new object();

            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotNull(nullObject, nameof(nullObject)));
        }

        [Test]
        public void ArgumentNull_NotNullArgument()
        {
            object notNullObject = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => Arguard.ArgumentNotNull(notNullObject, nameof(notNullObject)));

            StringAssert.Contains(nameof(notNullObject), ex.ParamName);
            StringAssert.Contains($"{nameof(notNullObject)} cannot be null", ex.Message);
        }

        [Test]
        public void ArgumentNotNull_NullArgument()
        {
            object nullObject = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => Arguard.ArgumentNotNull(nullObject, nameof(nullObject)));

            StringAssert.Contains(nameof(nullObject), ex.ParamName);
            StringAssert.Contains($"{nameof(nullObject)} cannot be null", ex.Message);
        }

        [Test]
        public void ArgumentNotNull_NotNullArgument()
        {
            object notNullObject = new object();

            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotNull(notNullObject, nameof(notNullObject)));
        }
    }
}
