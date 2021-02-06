using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arguard
{
    /// <summary>
    /// Class to provide a range of argument validation methods for Double scenarios.
    /// </summary>
    public static partial class Arguard
    {
        /// <summary>
        /// Checks a double argument to ensure it is zero.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentZero(double argumentValue, string argumentName)
            => ThrowArgumentExceptionIf(() => argumentValue != 0, argumentName, $"{argumentName} must be zero");

        /// <summary>
        /// Checks a double argument to ensure it is positive.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentPositive(double argumentValue, string argumentName)
            => ThrowArgumentExceptionIf(() => argumentValue <= 0, argumentName, $"{argumentName} must be positive");

        /// <summary>
        /// Checks a double argument to ensure it is negative.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNegative(double argumentValue, string argumentName)
            => ThrowArgumentExceptionIf(() => argumentValue >= 0, argumentName, $"{argumentName} must be negative");

        /// <summary>
        /// Checks a double argument to ensure it is not zero.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNotZero(double argumentValue, string argumentName) 
            => ThrowArgumentExceptionIf(() => argumentValue == 0, argumentName, $"{argumentName} cannot be zero");

        /// <summary>
        /// Checks a double argument to ensure it is not negative.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNotNegative(double argumentValue, string argumentName)
            => ThrowArgumentExceptionIf(() => argumentValue < 0, argumentName, $"{argumentName} cannot be negative");

        /// <summary>
        /// Checks a double argument to ensure is not positive.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNotPositive(double argumentValue, string argumentName)
            => ThrowArgumentExceptionIf(() => argumentValue > 0, argumentName, $"{argumentName} cannot be positive");

        /// <summary>
        /// Checks a double argument to ensure is greater than the specified value.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        /// <param name="argumentThreshold">Value that argument must exceed.</param>
        public static void ArgumentGreaterThan(double argumentValue, string argumentName, double argumentThreshold)
            => ThrowArgumentExceptionIf(() => argumentValue <= argumentThreshold, argumentName, $"{argumentName} must be greater than {argumentThreshold}");

        /// <summary>
        /// Checks a double argument to ensure is less than the specified value.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        /// <param name="argumentThreshold">Value that argument must not exceed.</param>
        public static void ArgumentLessThan(double argumentValue, string argumentName, double argumentThreshold)
            => ThrowArgumentExceptionIf(() => argumentValue >= argumentThreshold, argumentName, $"{argumentName} must be less than {argumentThreshold}");
    }
}
