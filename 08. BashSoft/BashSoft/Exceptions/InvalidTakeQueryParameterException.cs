namespace BashSoft.Exceptions
{
    using System;

    public class InvalidTakeQueryParameterException : Exception
    {
        private const string INVALID_TAKE_QUERY_PARAMETER = "The take command expected does not match the format wanted!";
        public InvalidTakeQueryParameterException() : base(INVALID_TAKE_QUERY_PARAMETER) { }
        public InvalidTakeQueryParameterException(string message) : base(message) { }
    }
}
