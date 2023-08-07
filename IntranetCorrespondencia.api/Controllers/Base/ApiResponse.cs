namespace IntranetCorrespondencia.api.Controllers.Base
{
    public class ApiResponse<TData>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ICollection<TData> Data { get; set; }

        public ApiResponse(int statusCode, string message, TData data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = new List<TData>() { data };
        }

        public ApiResponse(int statusCode, string message, ICollection<TData> data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public ApiResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
            Data = new List<TData>();
        }
    }
}
