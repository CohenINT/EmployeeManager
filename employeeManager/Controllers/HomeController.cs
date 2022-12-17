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


            string customerId = "q1tm1nWQbNAB9YvrZliWt";

            var customerAddresses = new List<Address>() { new Address()
             {

            Id = Nanoid.Nanoid.Generate(),
            IsDeleted = false,
            City = "new Jerzy",
            Created = DateTime.Now,
            CustomerId = customerId,
            Street = "alora dance"

             }};

            var contacts = new List<Contact>()
            {
            new Contact()
            {
                IsDeleted = false,
                Created= DateTime.Now,
                CustomerId = customerId,
                Email = "michale@gmail.com",
                FullName = "miachael",
                Id = Nanoid.Nanoid.Generate(),
                OfficeNumber = "+567-4711113"
            },
            new Contact()
            {
                IsDeleted = false,
                Created = DateTime.Now,
                CustomerId = customerId,
                Email = "shir.lior@gmail.com",
                FullName = "shior",
                Id = Nanoid.Nanoid.Generate(),
                OfficeNumber = "+514-999511"
            }
            };


            using (nogaDBContext context = new nogaDBContext())
            {
                try
                {
                    //await context.Customers.AddAsync(customer);
                    await context.Addresses.AddRangeAsync(customerAddresses);
                    await context.Contacts.AddRangeAsync(contacts);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {


                }
            }
        }

        public async Task<IActionResult> TestThis()
        {
            return Json("allgood");
        }

        public async Task<IActionResult> Customers([FromQuery] string Id)
        {
            var dto = await this.CustomerSvc.GetCustomer(Id);

            return View("Customers", dto);
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
