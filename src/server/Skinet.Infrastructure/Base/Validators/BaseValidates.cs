using System;

namespace Skinet.Infrastructure.Base.Validators
{
    public abstract class BaseValidates<TFailure, TRequest, TInfo>
    {
        protected Func<TRequest, TInfo> _returnInfo;
        protected Func<TInfo, TRequest, TFailure> _returnFailure;
        public abstract bool Valid(TInfo info, TRequest request);

        public BaseValidates<TFailure, TRequest, TInfo> ReturnFailure(Func<TInfo, TRequest, TFailure> returnFailure)
        {
            _returnFailure = returnFailure;
            return this;
        }
        
        public BaseValidates<TFailure, TRequest, TInfo> ReturnInfo(Func<TRequest, TInfo> returnInfo)
        {
            _returnInfo = returnInfo;
            return this;
        }

        public Result<TFailure, TRequest> Validate(TRequest request)
        {
            TInfo info = _returnInfo(request);

            if (Valid(info, request))
                return request;
            else
                return _returnFailure(info, request);
        }
    }
}