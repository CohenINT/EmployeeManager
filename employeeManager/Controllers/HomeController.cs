using employeeManager.Models;
using employeeManager.Models.DB;
using employeeManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nanoid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace employeeManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICustomerService CustomerSvc { set; get; }

        public HomeController(ILogger<HomeController> logger, ICustomerService CustomerService)
        {
            _logger = logger;
            this.CustomerSvc = CustomerService;
        }

        public async Task<IActionResult> Index()
        {
            List<CustomerDto> customers = await this.CustomerSvc.GetCustomers();

            return View("Index", customers);
        }

        private async Task TempCreateData()
        {
            //TODO: delete this function call to avoid inserting more data to db


            var customer = new Customer()
            {
                Created = DateTime.Now,
                IsDeleted = false,
                CustomerNumber = "5178787777",
                Id = Nanoid.Nanoid.Generate(),
                Name = "arold"
            };

            var customerAddresses = new List<Address>() { new Address()
             {

            Id = Nanoid.Nanoid.Generate(),
            IsDeleted = false,
            City = "new york",
            Created = DateTime.Now,
            CustomerId = customer.Id,
            Street = "zerim"

             }};

            var contacts = new List<Contact>() 
            {
            new Contact()
            {
                IsDeleted = false,
                Created= DateTime.Now, 
                CustomerId = customer.Id,
                Email = "kissnlove@gmail.com",
                FullName = "zari hembur",
                Id = Nanoid.Nanoid.Generate(),
                OfficeNumber = "+517-4777443"
            },
            new Contact()
            {
                IsDeleted = false,
                Created = DateTime.Now,
                CustomerId = customer.Id,
                Email = "miar.almoni@gmail.com",
                FullName = "miar almoni",
                Id = Nanoid.Nanoid.Generate(),
                OfficeNumber = "+315-12435447"
            }
            };


            using(nogaDBContext context = new nogaDBContext())
            {
                try
                {
                    await context.Customers.AddAsync(customer);
                    await context.Addresses.AddRangeAsync(customerAddresses);
                    await context.Contacts.AddRangeAsync(contacts);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    
                }
            }
        }

        public async Task<IActionResult> Customers()
        {
          

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
