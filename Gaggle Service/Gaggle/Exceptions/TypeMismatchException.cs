using System;

namespace GaggleService.Gaggle.Exceptions
{
    public class TypeMismatchException : Exception
    {
        public TypeMismatchException(string message) : base(message)
        {

        }

        public TypeMismatchException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
