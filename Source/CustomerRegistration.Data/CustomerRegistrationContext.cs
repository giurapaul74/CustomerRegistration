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
            modelBuilder.Entity<Customer>().HasOne(c => c.PostalAddress).WithMany().HasForeignKey(c => c.PostalAddressId).IsRequired();

            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    Street = "New Wantons",
                    Number = "56",
                    PostalCode= "762853",
                    City = "DC",
                    Country = "US"
                });
            
            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 2,
                    Street = "Checkery Street",
                    Number = "543",
                    PostalCode= "358394",
                    City = "New Orleans",
                    Country = "US"
                });

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Christian Undertow",
                    Website = "www.nonewrelevance.com",
                    EmailAddress = "chr.undr@gmail.com",
                    PhoneNumber = "555-1745-9745",
                    PostalAddressId = 1,
                    InvoiceAddressId= 1
                });
            
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 2,
                    Name = "Paul Blart",
                    Website = "www.emtspecials.com",
                    EmailAddress = "pl.blrt@gmail.com",
                    PhoneNumber = "555-8474-1732",
                    PostalAddressId = 2,
                    InvoiceAddressId= 2
                });
        }
    }
}
