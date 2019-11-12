using System;

namespace Prelude
{
    public class PreludeException : ApplicationException
    {
        public PreludeException(string message) : base(message)
        {
        }
    }
}