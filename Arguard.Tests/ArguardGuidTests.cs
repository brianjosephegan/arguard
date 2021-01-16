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
    public class ArguardGuidTests
    {
        [Test]
        public void ArgumentEmptyGuid_EmptyGuid()
        {
            Guid emptyGuid = Guid.Empty;

            Assert.DoesNotThrow(
                () => Arguard.ArgumentEmptyGuid(emptyGuid, nameof(emptyGuid)));
        }

        [Test]
        public void ArgumentEmptyGuid_ValidGuid()
        {
            Guid validGuid = Guid.NewGuid();

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentEmptyGuid(validGuid, nameof(validGuid)));

            StringAssert.Contains(nameof(validGuid), ex.ParamName);
            StringAssert.Contains($"{nameof(validGuid)} must be empty", ex.Message);
        }

        [Test]
        public void ArgumentNotEmptyGuid_ValidGuid()
        {
            Guid validGuid = Guid.NewGuid();

            Assert.DoesNotThrow(
                () => Arguard.ArgumentNotEmptyGuid(validGuid, nameof(validGuid)));
        }

        [Test]
        public void ArgumentNotEmptyGuid_EmptyGuid()
        {
            Guid emptyGuid = Guid.Empty;

            var ex = Assert.Throws<ArgumentException>(
                () => Arguard.ArgumentNotEmptyGuid(emptyGuid, nameof(emptyGuid)));

            StringAssert.Contains(nameof(emptyGuid), ex.ParamName);
            StringAssert.Contains($"{nameof(emptyGuid)} cannot be empty", ex.Message);
        }
    }
}
