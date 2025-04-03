namespace ZhouCaiFramework.Model
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public int Code { get; set; }
        public T Data { get; set; }

        public ApiResponse(int code, string message, T data)
        {
            Success = code == 200;
            Code = code;
            Message = message;
            Data = data;
        }
    }
}