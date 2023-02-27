using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBank.Exceptions
{
    public class BadParameterException : Exception
    {
        public BadParameterException(string message) : base(message) { }
        public BadParameterException(string message, Exception innerException) : base(message, innerException) { }
        public BadParameterException() : base() { }
    }
}
