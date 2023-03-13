using CustomerRegistration.Data;

namespace CustomerRegistration.Web.Models
{
    public class CustomerDetailsViewModel
    {
        public CustomerDetailsViewModel(string name, string website, string emailAddress, string phoneNumber, Address postalAddress, Address invoiceAddress) 
        {
            Name= name;
            Website= website;
            EmailAddress= emailAddress;
            PhoneNumber= phoneNumber;
            PostalAddress= postalAddress;
            InvoiceAddress= invoiceAddress;
        }

        public string Name { get; set; }
        public string Website { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public Address PostalAddress { get; set; }
        public Address InvoiceAddress { get; set; }

        public class Address
        {
            public Address(string street, string streetNumber, string postalCode, string city, string country)
            {
                Street = street;
                StreetNumber = streetNumber;
                PostalCode = postalCode;
                City = city;
                Country = country;
            }

            public string Street { get; set; }
            public string StreetNumber { get; set; }
            public string PostalCode { get; set; }
            public string City { get; set; }
            public string Country { get; set; }

            public override string ToString()
            {
                return $"{Street} {StreetNumber}\n{City}, {Country}\n{PostalCode}";
            }
        }
    }
}
