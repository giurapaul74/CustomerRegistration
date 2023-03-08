using CustomerRegistration.Data;
using CustomerRegistration.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerDetails(int customerId)
        {
            var customerDetailsViewModel = _context.Customers
                .Where(customer => customer.Id== customerId)
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
                        customer.PostalAddress.Street,
                        customer.PostalAddress.Number,
                        customer.PostalAddress.PostalCode,
                        customer.PostalAddress.City,
                        customer.PostalAddress.Country)))
                .SingleOrDefaultAsync();

            return View(customerDetailsViewModel);
        }
    }
}
