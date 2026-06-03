using RotsPapierSchaar.Application.ResultPattern;

namespace RotsPapierSchaar.Application.Exceptions
{
    public abstract class CustomException : Exception
    {
        public ErrorCode ErrorCode { get; }

        protected CustomException(ErrorCode errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
