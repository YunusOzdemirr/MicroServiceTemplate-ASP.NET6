using MicroServiceTemplate.Domain.Enums;

namespace MicroServiceTemplate.Domain.Common
{
    public class Result : IResult
    {
        public List<string> Messages { get; set; } = new List<string>();
        public bool Succeeded { get; set; }
        public object? Data { get; set; }
        public ResultStatus ResultStatus { get; set; }

        public static IResult Fail()
        {
            return new Result { ResultStatus = ResultStatus.Error, Succeeded = false };
        }
        public static IResult Fail(string message)
        {
            return new Result { ResultStatus = ResultStatus.Error, Succeeded = false, Messages = new List<string>() { message } };
        }
        public static IResult Fail(List<string> messages)
        {
            return new Result { ResultStatus = ResultStatus.Error, Succeeded = false, Messages = messages };
        }
        public static Task<IResult> FailAsync()
        {
            return Task.FromResult(Fail());
        }
        public static Task<IResult> FailAsync(string message)
        {
            return Task.FromResult(Fail(message));
        }
        public static Task<IResult> FailAsync(List<string> messages)
        {
            return Task.FromResult(Fail(messages));
        }
        public static IResult Success()
        {
            return new Result { ResultStatus = ResultStatus.Success, Succeeded = true };
        }
        public static IResult Success(string message)
        {
            return new Result { ResultStatus = ResultStatus.Success, Succeeded = true, Messages = new List<string> { message } };
        }
        public static IResult Success(string message, object data)
        {
            return new Result { ResultStatus = ResultStatus.Success, Succeeded = true, Messages = new List<string> { message }, Data = data };
        }
        public static IResult Success(List<string> messages)
        {
            return new Result { ResultStatus = ResultStatus.Success, Succeeded = true, Messages = messages };
        }
        public static Task<IResult> SuccessAsync()
        {
            return Task.FromResult(Success());
        }
        public static Task<IResult> SuccessAsync(string message, object data)
        {
            return Task.FromResult(Success(message));
        }
        public static Task<IResult> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }
        public static Task<IResult> SuccessAsync(List<string> messages)
        {
            return Task.FromResult(Success(messages));
        }
    }
}