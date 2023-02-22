namespace Bakim.Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(string message, bool success) : this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; set; }
        public string Message { get; set; }

    }
}
