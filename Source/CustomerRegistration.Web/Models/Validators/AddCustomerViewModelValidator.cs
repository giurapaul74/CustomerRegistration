using FluentValidation;

namespace CustomerRegistration.Web.Models.Validators
{
    public class AddCustomerViewModelValidator : AbstractValidator<AddCustomerViewModel>
    {
        public AddCustomerViewModelValidator() 
        {
            RuleFor(customer => customer.Name).NotEmpty().MaximumLength(200);
            RuleFor(customer => customer.Website).MaximumLength(100);
            RuleFor(customer => customer.EmailAddress).MaximumLength(100);
            RuleFor(customer => customer.PhoneNumber).NotEmpty().MaximumLength(15);
            RuleFor(customer => customer.PostalAddressStreet).MaximumLength(100);
            RuleFor(customer => customer.PostalAddressStreetNumber).MaximumLength(100);
            RuleFor(customer => customer.PostalAddressPostalCode).MaximumLength(100);
            RuleFor(customer => customer.PostalAddressCity).MaximumLength(100);
            RuleFor(customer => customer.PostalAddressCountry).MaximumLength(100);

            RuleSet("InvoiceAddress", () =>
            {
                RuleFor(customer => customer.InvoiceAddressStreet).NotEmpty().When(address => address.IsInvoiceAddressDifferent);
                RuleFor(customer => customer.InvoiceAddressStreetNumber).NotEmpty().When(address => address.IsInvoiceAddressDifferent);
                RuleFor(customer => customer.InvoiceAddressPostalCode).NotEmpty().When(address => address.IsInvoiceAddressDifferent);
                RuleFor(customer => customer.InvoiceAddressCity).NotEmpty().When(address => address.IsInvoiceAddressDifferent);
                RuleFor(customer => customer.InvoiceAddressCountry).NotEmpty().When(address => address.IsInvoiceAddressDifferent);
            });
        }
    }
}
