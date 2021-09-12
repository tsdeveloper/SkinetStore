using System;
using Skinet.Infrastructure.Base;

namespace Skinet.Infrastructure.Extensions
{
    public static class Result
    {
        #region Bind

        public static Result<TFailure, NewTSuccess> Bind<TFailure, TSuccess, NewTSuccess>(
            this Result<TFailure, TSuccess> @Result,
            Func<TSuccess, Result<TFailure, NewTSuccess>> func
        )
            => @Result.IsSuccess
                ? func(@Result.Success)
                : Result<TFailure, NewTSuccess>.Of(@Result.Failure);

        #endregion
    }
}