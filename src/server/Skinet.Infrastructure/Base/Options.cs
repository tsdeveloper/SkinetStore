using Skinet.Infrastructure.Helpers;

namespace Skinet.Infrastructure.Base
{
    public partial struct Options<T>
    {
        public T Value { get; }

        public bool IsSome { get;}
        public bool IsNone => !IsSome;

        internal Options(T value, bool isSome)
        {
            Value = value;
            IsSome = isSome;
        }

        public static readonly Options<T> None = new Options<T>();
        // public static implicit operator Options<T>(T value) => Some(value);
        public static implicit operator Options<T>(NoneType _) => None;


    }
}