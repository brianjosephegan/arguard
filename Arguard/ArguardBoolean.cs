using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arguard
{
    /// <summary>
    /// Class to provide a range of argument validation methods for Boolean scenarios.
    /// </summary>
    public static partial class Arguard
    {
        /// <summary>
        /// Checks a boolean argument to ensure it is true.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentTrue(bool argumentValue, string argumentName)
            => ThrowArgumentExceptionIf(() => argumentValue != true, argumentName, $"{argumentName} must be true");

        /// <summary>
        /// Checks a boolean argument to ensure it is true.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentFalse(bool argumentValue, string argumentName)
            => ThrowArgumentExceptionIf(() => argumentValue != false, argumentName, $"{argumentName} must be false");
    }
}
