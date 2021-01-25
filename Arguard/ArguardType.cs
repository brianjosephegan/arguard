using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arguard
{
    /// <summary>
    /// Class to provide a range of argument validation methods for Type scenarios.
    /// </summary>
    public static partial class Arguard
    {
        /// <summary>
        /// Checks an object argument to ensure it is of a certain type.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        ///         /// <param name="expectedType">Expected type of the argument being validated.</param>
        public static void ArgumentType(object argumentValue, string argumentName, Type expectedType)
            => ThrowArgumentExceptionIf(() => argumentValue.GetType() != expectedType, argumentName, $"{argumentName} must be of type {expectedType}");

        /// <summary>
        /// Checks an object argument to ensure it is not of a certain type.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        /// <param name="expectedType">Expected type of the argument being validated.</param>
        public static void ArgumentNotType(object argumentValue, string argumentName, Type expectedType)
            => ThrowArgumentExceptionIf(() => argumentValue.GetType() == expectedType, argumentName, $"{argumentName} cannot be of type {expectedType}");
    }
}
