using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Core.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; }   //read only
        string Message { get; }

    }
}
