namespace Core.Common
{
    public sealed class BaseReturn<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
        public int Count { get; set; }
    }
}