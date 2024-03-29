﻿using System.ComponentModel.DataAnnotations;

namespace CustomerRegistration.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int PostalAddressId { get; set; }
        public Address PostalAddress { get; set; }
        public int InvoiceAddressId { get; set; }
        public Address InvoiceAddress { get; set; }
    }
}