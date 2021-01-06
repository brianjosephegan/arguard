using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guard
{
    /// <summary>
    /// Class to provide a range of argument validation methods.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Checks an argument to ensure it isn't null.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNotNull(object argumentValue, string argumentName)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName, $"{argumentName} cannot be null");
            }
        }

        /// <summary>
        /// Checks a string argument to ensure it isn't empty.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNotEmptyString(string argumentValue, string argumentName)
        {
            if (string.IsNullOrEmpty(argumentValue))
            {
                throw new ArgumentException($"{argumentName} cannot be empty", argumentName);
            }
        }

        /// <summary>
        /// Checks an enumerable argument to ensure it isn't empty.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNotEmptyCollection<T>(IEnumerable<T> argumentValue, string argumentName)
        {
            if (!argumentValue.Any())
            {
                throw new ArgumentException($"{argumentName} cannot be empty", argumentName);
            }
        }

        /// <summary>
        /// Checks an long argument to ensure it isn't negative.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNotNegative(long argumentValue, string argumentName)
        {
            if (argumentValue < 0)
            {
                throw new ArgumentException($"{argumentName} cannot be negative", argumentName);
            }
        }

        /// <summary>
        /// Checks an double argument to ensure it isn't negative.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNotNegative(double argumentValue, string argumentName)
        {
            if (argumentValue < 0)
            {
                throw new ArgumentException($"{argumentName} cannot be negative", argumentName);
            }
        }

        /// <summary>
        /// Checks to ensure that the GUID is not empty.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNotEmptyGuid(Guid argumentValue, string argumentName)
        {
            if (argumentValue == Guid.Empty)
            {
                throw new ArgumentException($"{argumentName} cannot be empty", argumentName);
            }
        }
    }
}
