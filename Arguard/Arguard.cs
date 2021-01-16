using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arguard
{
    /// <summary>
    /// Class to provide a range of argument validation methods for scenarios.
    /// </summary>
    /// <remarks>
    /// This partial class will hold any common methods used by the
    /// type-specific classes that make up this class as a whole.
    /// </remarks>
    public static partial class Arguard
    {
        /// <summary>
        /// Checks if the specified <paramref name="condition"/> is met and, if true, throws an <see cref="ArgumentException"/>.
        /// </summary>
        /// <param name="condition">Condition to evaluate.</param>
        /// <param name="argumentName">Name of the argument being validated.</param>
        /// <param name="exceptionMessage">Message to use in the exception.</param>
        private static void ThrowArgumentExceptionIf(Func<bool> condition, string argumentName, string exceptionMessage)
        {
            if (condition())
            {
                throw new ArgumentException(message: exceptionMessage, paramName: argumentName);
            }
        }

        /// <summary>
        /// Checks if the specified <paramref name="condition"/> is met and, if true, throws an <see cref="ArgumentNullException"/>.
        /// </summary>
        /// <param name="condition">Condition to evaluate.</param>
        /// <param name="argumentName">Name of the argument being validated.</param>
        /// <param name="exceptionMessage">Message to use in the exception.</param>
        private static void ThrowArgumentNullExceptionIf(Func<bool> condition, string argumentName, string exceptionMessage)
        {
            if (condition())
            {
                throw new ArgumentNullException(message: exceptionMessage, paramName: argumentName);
            }
        }
    }
}
