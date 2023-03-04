using Microsoft.EntityFrameworkCore;

namespace CustomerRegistration.Data
{
    public class CustomerRegistrationContext : DbContext
    {
        public CustomerRegistrationContext(DbContextOptions<CustomerRegistrationContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(a => a.Id);
            modelBuilder.Entity<Address>().HasKey(a => a.Id);
        }
    }
}
