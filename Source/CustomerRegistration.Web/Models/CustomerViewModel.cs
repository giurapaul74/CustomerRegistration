using CustomerRegistration.Data;

namespace CustomerRegistration.Web.Models
{
    public class CustomerViewModel 
    {
        public IEnumerable<Customer> Customers { get; }

        public CustomerViewModel(IEnumerable<Customer> customers) 
        { 
            Customers = customers;
        }

        public class Customer
        {
            public Customer(int id, string name, string website, string emailAddress, string phoneNumber)
            {
                Id = id;
                Name = name;
                Website = website;
                EmailAddress = emailAddress;
                PhoneNumber = phoneNumber;
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public string Website { get; set; }
            public string EmailAddress { get; set; }
            public string PhoneNumber { get; set; }
        }
    }
}
