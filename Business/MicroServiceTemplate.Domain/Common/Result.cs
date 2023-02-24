using MicroServiceTemplate.Domain.Enums;

namespace MicroServiceTemplate.Domain.Common
{
    public class Result : IResult
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public object Data { get; set; }
        public ResultStatus ResultStatus { get; set; }

        public static async Task<IResult> FailAsync()
        {
            var result = new Result { ResultStatus = ResultStatus.Error, Succeeded = false };
            return await Task.FromResult(result);
        }

        public static async Task<IResult> FailAsync(ResultStatus resultStatus)
        {
            var result = new Result { ResultStatus = resultStatus, Succeeded = false };
            return await Task.FromResult(result);
        }

        public static async Task<IResult> FailAsync(string message)
        {
            var result = new Result { ResultStatus = ResultStatus.Error, Succeeded = false, Message = message };
            return await Task.FromResult(result);
        }

        public static async Task<IResult> FailAsync(string message, ResultStatus resultStatus)
        {
            var result = new Result { ResultStatus = resultStatus, Succeeded = false, Message = message };
            return await Task.FromResult(result);
        }

        public static async Task<IResult> SuccessAsync()
        {
            var result = new Result { ResultStatus = ResultStatus.Success, Succeeded = true };
            return await Task.FromResult(result);
        }

        public static async Task<IResult> SuccessAsync(object data)
        {
            var result = new Result { ResultStatus = ResultStatus.Success, Succeeded = true, Data = data };
            return await Task.FromResult(result);
        }

        public static async Task<IResult> SuccessAsync(string message)
        {
            var result = new Result { ResultStatus = ResultStatus.Success, Succeeded = true, Message = message };
            return await Task.FromResult(result);
        }

        public static async Task<IResult> SuccessAsync(string message, object data)
        {
            var result = new Result
                { ResultStatus = ResultStatus.Success, Succeeded = true, Message = message, Data = data };
            return await Task.FromResult(result);
        }
    }

    public class Result<T> : IResult<T>
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public object Data { get; set; }
        public ResultStatus ResultStatus { get; set; }

        public static async Task<IResult<T>> FailAsync()
        {
            var result = new Result<T> { ResultStatus = ResultStatus.Error, Succeeded = false };
            return await Task.FromResult(result);
        }

        public static async Task<IResult<T>> FailAsync(ResultStatus resultStatus)
        {
            var result = new Result<T> { ResultStatus = resultStatus, Succeeded = false };
            return await Task.FromResult(result);
        }

        public static async Task<IResult<T>> FailAsync(string message, ResultStatus resultStatus)
        {
            var result = new Result<T> { ResultStatus = resultStatus, Succeeded = false, Message = message };
            return await Task.FromResult(result);
        }

        public static async Task<IResult<T>> FailAsync(string message)
        {
            var result = new Result<T> { ResultStatus = ResultStatus.Error, Succeeded = false, Message = message };
            return await Task.FromResult(result);
        }

        public static async Task<IResult<T>> FailAsync(T data)
        {
            var result = new Result<T> { ResultStatus = ResultStatus.Error, Succeeded = false, Data = data };
            return await Task.FromResult(result);
        }

        public static async Task<IResult<T>> FailAsync(string message, T data)
        {
            var result = new Result<T>
                { ResultStatus = ResultStatus.Error, Succeeded = false, Message = message, Data = data };
            return await Task.FromResult(result);
        }

        public static async Task<IResult<T>> SuccessAsync(T data)
        {
            var result = new Result<T> { ResultStatus = ResultStatus.Success, Succeeded = true, Data = data };
            return await Task.FromResult(result);
        }

        public static async Task<IResult<T>> SuccessAsync()
        {
            var result = new Result<T> { ResultStatus = ResultStatus.Success, Succeeded = true };
            return await Task.FromResult(result);
        }

        public static async Task<IResult<T>> SuccessAsync(string message)
        {
            var result = new Result<T> { ResultStatus = ResultStatus.Success, Succeeded = true, Message = message };
            return await Task.FromResult(result);
        }

        public static async Task<IResult<T>> SuccessAsync(string message, T data)
        {
            var result = new Result<T>
                { ResultStatus = ResultStatus.Success, Succeeded = true, Message = message, Data = data };
            return await Task.FromResult(result);
        }
    }
}