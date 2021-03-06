﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arguard
{
    /// <summary>
    /// Class to provide a range of argument validation methods for GUID scenarios.
    /// </summary>
    public static partial class Arguard
    {
        /// <summary>
        /// Checks to ensure that the GUID is empty.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentEmptyGuid(Guid argumentValue, string argumentName)
            => ThrowArgumentExceptionIf(() => argumentValue != Guid.Empty, argumentName, $"{argumentName} must be empty");


        /// <summary>
        /// Checks to ensure that the GUID is not empty.
        /// </summary>
        /// <param name="argumentValue">Specifies the argument value to check.</param>
        /// <param name="argumentName">Specifies the name of the argument.</param>
        public static void ArgumentNotEmptyGuid(Guid argumentValue, string argumentName)
            => ThrowArgumentExceptionIf(() => argumentValue == Guid.Empty, argumentName, $"{argumentName} cannot be empty");
    }
}
