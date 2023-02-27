using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBank.Exceptions
{
    public class UnauthorizeAccessException : Exception
    {
        public UnauthorizeAccessException(string message) : base(message) { }
        public UnauthorizeAccessException(string message, Exception innerException) : base(message, innerException) { }
        public UnauthorizeAccessException() : base() { }
    }
}
