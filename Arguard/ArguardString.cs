using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arguard
{
    /// <summary>
    /// Class to provide a range of argument validation methods for string scenarios.
    /// </summary>
    public static partial class Arguard
    {
        /// <summary>
        /// Checks a string argument to ensure it is empty.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentEmpty(string argumentValue, string argumentName)
            => ThrowArgumentExceptionIf(() => !string.IsNullOrEmpty(argumentValue), argumentName, $"{argumentName} must be empty");

        /// <summary>
        /// Checks a string argument to ensure it is not empty.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNotEmpty(string argumentValue, string argumentName)
            => ThrowArgumentExceptionIf(() => string.IsNullOrEmpty(argumentValue), argumentName, $"{argumentName} cannot be empty");

        /// <summary>
        /// Checks a string argument to ensure it is of a specified length.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentLength(string argumentValue, string argumentName, int expectedLength)
            => ThrowArgumentExceptionIf(() => argumentValue.Length != expectedLength, argumentName, $"{argumentName} must be of length {expectedLength}");

        /// <summary>
        /// Checks a string argument to ensure it is not of a specified length.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNotLength(string argumentValue, string argumentName, int expectedLength)
            => ThrowArgumentExceptionIf(() => argumentValue.Length == expectedLength, argumentName, $"{argumentName} cannot be of length {expectedLength}");
    }
}
