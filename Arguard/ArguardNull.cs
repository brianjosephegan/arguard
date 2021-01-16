using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arguard
{
    /// <summary>
    /// Class to provide a range of argument validation methods for null scenarios.
    /// </summary>
    public static partial class Arguard
    {
        /// <summary>
        /// Checks an argument to ensure it is null.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNull(object argumentValue, string argumentName)
            => ThrowArgumentExceptionIf(() => argumentValue != null, argumentName, $"{argumentName} must be null");

        /// <summary>
        /// Checks an argument to ensure it isn't null.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNotNull(object argumentValue, string argumentName)
            => ThrowArgumentNullExceptionIf(() => argumentValue == null, argumentName, $"{argumentName} cannot be null");

    }
}
