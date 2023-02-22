namespace Bakim.Core.Utilities.Results
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(T data, string message, bool success) : this(success)
        {
            Data = data;
            Message = message;
        }
        public DataResult(T data, bool success) : this(success)
        {
            Data = data;
        }
        public DataResult(bool success)
        {
            Success = success;
        }
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
