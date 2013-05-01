// File: InvalidDateTimeFormatException.cs
// Project Name: NCmdLiner
// Project Home: https://github.com/trondr
// License: New BSD License (BSD) http://www.opensource.org/licenses/BSD-3-Clause
// Credits: See the credits folder in this project
// Copyright � <github.com/trondr> 2013 
// All rights reserved.

namespace NCmdLiner.Exceptions
{
    /// <summary>  Exception for signalling NCmdLiner date time format errors. </summary>
    ///
    /// <remarks>  Trond, 03.10.2012. </remarks>
    public sealed class InvalidDateTimeFormatException : NCmdLinerException
    {
        public InvalidDateTimeFormatException(string message, params object[] arguments) : base(message, arguments)
        {
        }
    }
}