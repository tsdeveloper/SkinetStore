using Microsoft.EntityFrameworkCore;

namespace Skinet.Infrastructure.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
            
        }
        
        
    }
}