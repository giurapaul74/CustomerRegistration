using CustomerRegistration.Data;
using CustomerRegistration.Web.Models;
using CustomerRegistration.Web.Models.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace CustomerRegistration.Web.Controllers
{
    [Route("Customer")]
    public class CustomerController : Controller
    {
        private readonly CustomerRegistrationContext _context;

        public CustomerController(CustomerRegistrationContext context)
        {
            _context = context;
        }

        [HttpGet("Customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _context.Customers
                .Select(customer => new CustomerViewModel.Customer(customer.Id, customer.Name,
                customer.Website, customer.EmailAddress, customer.PhoneNumber))
                .ToListAsync();

            CustomerViewModel customerViewModel = new CustomerViewModel(customers);

            return View(customerViewModel);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerDetails(int customerId)
        {
            var customerDetailsViewModel = await _context.Customers
                .Where(customer => customer.Id == customerId)
                .Select(customer => new CustomerDetailsViewModel(
                    customer.Name,
                    customer.Website,
                    customer.EmailAddress,
                    customer.PhoneNumber,
                    new CustomerDetailsViewModel.Address(
                        customer.PostalAddress.Street,
                        customer.PostalAddress.Number,
                        customer.PostalAddress.PostalCode,
                        customer.PostalAddress.City,
                        customer.PostalAddress.Country),
                    new CustomerDetailsViewModel.Address(
                        customer.InvoiceAddress.Street,
                        customer.InvoiceAddress.Number,
                        customer.InvoiceAddress.PostalCode,
                        customer.InvoiceAddress.City,
                        customer.InvoiceAddress.Country)))
                .SingleOrDefaultAsync();

            if (customerDetailsViewModel is null)
            {
                return View("ErrorMessage", new ErrorMessageViewModel($"Customer with ID {customerId} could not be found."));
            }

            return View(customerDetailsViewModel);
        }

        [HttpGet("AddCustomer")]
        public IActionResult AddCustomer()
        {
            return View();
        }


        [HttpPost("AddCustomer")]
        [ValidateAntiForgeryToken]
        public IActionResult AddCustomer(AddCustomerViewModel model)
        {
            var validator = new AddCustomerViewModelValidator();
            var result = validator.Validate(model);

            if (!result.IsValid)
            {

                // The model is invalid, display validation errors to the user
                foreach (var failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }

                return View(model);
            }
            else
            {
                var customer = new Customer
                {
                    Name = model.Name,
                    Website = model.Website,
                    EmailAddress = model.EmailAddress,
                    PhoneNumber = model.PhoneNumber,
                    PostalAddress = new Address
                    {
                        Street = model.PostalAddressStreet,
                        Number = model.PostalAddressStreetNumber,
                        PostalCode = model.PostalAddressPostalCode,
                        City = model.PostalAddressCity,
                        Country = model.PostalAddressCountry
                    },
                };

                if (!model.IsInvoiceAddressDifferent)
                {
                    customer.InvoiceAddress = customer.PostalAddress;
                }
                else
                {
                    customer.InvoiceAddress = new Address
                    {
                        Street = model.InvoiceAddressStreet,
                        Number = model.InvoiceAddressStreetNumber,
                        PostalCode = model.InvoiceAddressPostalCode,
                        City = model.InvoiceAddressCity,
                        Country = model.InvoiceAddressCountry
                    };
                }

                _context.Customers.Add(customer);
                _context.SaveChanges();
            }

            return RedirectToAction("Customers");
        }
    }
}
