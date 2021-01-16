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
    }
}
