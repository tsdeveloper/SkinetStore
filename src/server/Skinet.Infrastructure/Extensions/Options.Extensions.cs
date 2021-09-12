using Skinet.Infrastructure.Base;

namespace Skinet.Infrastructure.Extensions
{
    public static class Options
    {
        public static Options<T> Of<T>(T value) => new Options<T>(value, value != null);

    }
}