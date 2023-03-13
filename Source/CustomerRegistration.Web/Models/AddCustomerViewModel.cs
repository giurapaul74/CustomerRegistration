namespace CustomerRegistration.Web.Models
{
    public class AddCustomerViewModel
    {
        //public AddCustomerViewModel(string name, string website, string emailAddress, string phoneNumber, 
        //    string postalAddressStreet, int postalAddressStreetNumber, string postalAddressPostalCode, string postalAddressCity,
        //    string postalAddressCountry, string invoiceAddressStreet, int invoiceAddressStreetNumber, string invoiceAddressPostalCode,
        //    string invoiceAddressCity, string invoiceAddressCountry)
        //{
        //    Name= name;
        //    Website= website;
        //    EmailAddress= emailAddress;
        //    PhoneNumber= phoneNumber;
        //    PostalAddressStreet= postalAddressStreet;
        //    PostalAddressStreetNumber= postalAddressStreetNumber;
        //    PostalAddressPostalCode= postalAddressPostalCode;
        //    PostalAddressCity= postalAddressCity;
        //    PostalAddressCountry= postalAddressCountry;
        //    InvoiceAddressStreet= invoiceAddressStreet;
        //    InvoiceAddressStreetNumber= invoiceAddressStreetNumber;
        //    InvoiceAddressPostalCode= invoiceAddressPostalCode;
        //    InvoiceAddressCity= invoiceAddressCity;
        //    InvoiceAddressCountry= invoiceAddressCountry;
        //}

        public string Name { get; set; }
        public string Website { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalAddressStreet { get; set; }
        public string PostalAddressStreetNumber { get; set; }
        public string PostalAddressPostalCode { get; set; }
        public string PostalAddressCity { get; set; }
        public string PostalAddressCountry { get; set; }
        public string InvoiceAddressStreet { get; set; }
        public string InvoiceAddressStreetNumber { get; set; }
        public string InvoiceAddressPostalCode { get; set; }
        public string InvoiceAddressCity { get; set; }
        public string InvoiceAddressCountry { get; set; }
        public bool IsInvoiceAddressDifferent { get; set; }
    }
}
