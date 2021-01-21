using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arguard
{
    /// <summary>
    /// Class to provide a range of argument validation methods for IEnumerable scenarios.
    /// </summary>
    public static partial class Arguard
    {
        /// <summary>
        /// Checks an enumerable argument to ensure it is empty.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentEmpty<T>(IEnumerable<T> argumentValue, string argumentName)
            => ThrowArgumentExceptionIf(() => argumentValue.Any(), argumentName, $"{argumentName} must be empty");

        /// <summary>
        /// Checks an enumerable argument to ensure it is not empty.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNotEmpty<T>(IEnumerable<T> argumentValue, string argumentName)
            => ThrowArgumentExceptionIf(() => !argumentValue.Any(), argumentName, $"{argumentName} cannot be empty");

        /// <summary>
        /// Checks an enumerable argument to ensure it does not contain any nulls.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNoNulls<T>(IEnumerable<T> argumentValue, string argumentName)
            => ThrowArgumentExceptionIf(() => argumentValue.Any(v => v == null), argumentName, $"{argumentName} cannot contain nulls");
    }
}
