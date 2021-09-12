namespace Skinet.Infrastructure.Base.Responses
{
    public class BaseResponses
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public TypeResponse TypeResponse { get; set; }
        public string Description { get; set; }
    }

    public enum TypeResponse
    {
        Infor = 0,
        Warning = 1,
        Error = 2
    }
}