using System;

namespace Skinet.Infrastructure.Base
{
    public struct Result<TFailure, TSuccess>
    {
        
        /// <summary>
        ///
        /// Essa classe tem o objetivo de fornecer um retorno mais expressivo dos resultados de um função
        /// Ao realizar uma chamada para um Object podemos ter como resultado: Exception, null ou Object
        ///
        /// Ex 1: Result<Exception, Customer> t;
        ///     Se IsFailure é True, temos uma instancia de uma Exception
        ///     Se IsSucess é True, temos uma instancia de um Customer
        ///
        /// Ex 2: Result<Exception, Success>
        ///     Para Success é necessário fazer o retorno de Unit.Successful
        ///
        /// </summary>
        /// <typeparam name="TFailure"></typeparam>
        /// <typeparam name="TSuccess"></typeparam>
        public TFailure Failure { get; internal set; }
        public TSuccess Success { get; internal set; }

        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        // public Options<TFailure> OptionsFailure => IsFailure ? Some(Failure) : None;
        // public Options<TSuccess> OptionsSuccess => IsSuccess ? Some(Success) : None;

        internal Result(TFailure failure)
        {
            IsFailure = true;
            Failure = failure;
            Success = default(TSuccess);
        }
        
        internal Result(TSuccess success)
        {
            IsFailure = false;
            Success = success;
            Failure = default(TFailure);
        }

        public TResult Match<TResult>(
            Func<TFailure, TResult> failure,
            Func<TSuccess, TResult> success
        ) => IsFailure ? failure(Failure) : success(Success);

        public static implicit operator Result<TFailure, TSuccess>(TFailure obj)
            => new(obj);
        
        public static implicit operator Result<TFailure, TSuccess>(TSuccess obj)
            => new(obj);

        public static Result<TFailure, TSuccess> Of(TSuccess obj) => obj;
        public static Result<TFailure, TSuccess> Of(TFailure obj) => obj;


    }
}