using Microsoft.EntityFrameworkCore;

namespace Skinet.Infrastructure.Context
{
    public static class DbContextExtensions
    {
        public static DbSet<T> DbSet<T>(this StoreContext context)
        where T : class
        {
            return context.Set<T>();
        }
    }
}