namespace Skinet.Infrastructure.Base.Validators.Request
{
    public class ValidateRequest<TFailure, TSuccess> : BaseValidates<TFailure, TSuccess, object>
    {
        public override bool Valid(object info, TSuccess request)
        {
            return info != null;
        }
    }
}