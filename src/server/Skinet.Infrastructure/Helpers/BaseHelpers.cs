using Skinet.Infrastructure.Base;
using Skinet.Infrastructure.Extensions;

namespace Skinet.Infrastructure.Helpers
{
    public static partial class BaseHelpers
    {
        public static Options<T> Some<T>(T value) => Options.Of(value);
        public static readonly NoneType None = new NoneType();
        
        
        /*private static readonly Unit unit = new Unit();

        public static Unit Unit() => unit;

        public static Func<T, Unit> ToFunc<T>(Action<T> action) => o =>
        {
            action(o);
            return Unit();
        };

        public static Func<Unit> ToFunc(Action action) => () =>
        {
            action();
            return Unit();
        };*/
    }
}