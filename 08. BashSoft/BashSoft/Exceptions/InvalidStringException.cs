namespace BashSoft.Exceptions
{
    using System;

    public class InvalidStringException : Exception
    {
        private const string NULL_OR_EMPTY_VALUE = "The value of the variable CANNOT be null or empty!";
        public InvalidStringException() : base(NULL_OR_EMPTY_VALUE) { }
        public InvalidStringException(string message) : base(message) { }
    }
}
