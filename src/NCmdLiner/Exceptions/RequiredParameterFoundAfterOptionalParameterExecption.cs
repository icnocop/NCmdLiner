// File: RequiredParameterFoundAfterOptionalParameterExecption.cs
// Project Name: NCmdLiner
// Project Home: https://github.com/trondr
// License: New BSD License (BSD) http://www.opensource.org/licenses/BSD-3-Clause
// Credits: See the credits folder in this project
// Copyright � <github.com/trondr> 2013 
// All rights reserved.

namespace NCmdLiner.Exceptions
{
    public class RequiredParameterFoundAfterOptionalParameterExecption : NCmdLinerException
    {
        public RequiredParameterFoundAfterOptionalParameterExecption(string message) : base(message)
        {
        }
    }
}