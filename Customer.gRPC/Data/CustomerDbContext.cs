using Microsoft.EntityFrameworkCore;

namespace Customer.gRPC.Data
{
    public class CustomerDbContext(DbContextOptions<CustomerDbContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers => Set<Customer>();
    }
}
