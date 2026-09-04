using Microsoft.EntityFrameworkCore;

namespace Order.gRPC.Data
{
    public class OrderDbContext(DbContextOptions<OrderDbContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders =>Set<Order>();
    }
}
