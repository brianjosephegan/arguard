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
        public static void ArgumentNotNull(object argumentValue, string argumentName)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName, $"{argumentName} cannot be null");
            }
        }
    }
}
