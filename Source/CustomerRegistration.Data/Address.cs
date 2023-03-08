using System.ComponentModel.DataAnnotations;

namespace CustomerRegistration.Data
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}