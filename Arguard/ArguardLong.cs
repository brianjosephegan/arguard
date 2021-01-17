using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arguard
{
    /// <summary>
    /// Class to provide a range of argument validation methods for long scenarios.
    /// </summary>
    public static partial class Arguard
    {
        /// <summary>
        /// Checks an long argument to ensure it is not zero.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNotZero(long argumentValue, string argumentName)
            => ThrowArgumentExceptionIf(() => argumentValue == 0, argumentName, $"{argumentName} cannot be zero");

        /// <summary>
        /// Checks an long argument to ensure it not negative.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNotNegative(long argumentValue, string argumentName)
            => ThrowArgumentExceptionIf(() => argumentValue < 0, argumentName, $"{argumentName} cannot be negative");

        /// <summary>
        /// Checks an long argument to ensure it is not positive.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNotPositive(long argumentValue, string argumentName)
            => ThrowArgumentExceptionIf(() => argumentValue > 0, argumentName, $"{argumentName} cannot be positive");
    }
}
