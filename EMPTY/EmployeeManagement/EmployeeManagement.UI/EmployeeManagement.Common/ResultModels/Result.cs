namespace EmployeeManagement.Common.ResultModels
{
    public class Result<T> : IResult
    {
        public bool IsSucces { get ; set ; }
        public string Message { get; set ; }

        public T Data { get; set ; }

        public int TotalCount { get; set ; }
        public Result(bool isSuccess,string message):this(isSuccess,message,default(T))
        {

        }
        public Result(bool isSuccess, string message, T data) : this(isSuccess, message,data,0)
        {

        }
        public Result(bool isSuccess, string message ,T data ,int totalCount)
        {
            IsSucces = isSuccess;
            Message = message;
            Data = data;
            TotalCount = totalCount;
        }

    }
}
