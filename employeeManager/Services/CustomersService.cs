using employeeManager.Models;
using employeeManager.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employeeManager.Services
{
    public class CustomersService : ICustomerService
    {
        private ILogger<CustomersService> log;

        public CustomersService(ILogger<CustomersService> logging)
        {
            this.log = logging;
        }

        public async Task<bool> CreateNewCustomer(Customer customer, List<Contact> contacts)
        {
            using (nogaDBContext context = new nogaDBContext())
            {
                try
                {
                    await context.Customers.AddAsync(customer);
                    await context.Contacts.AddRangeAsync(contacts);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    this.log.LogError(ex, "failed to update db");
                    return await Task.FromResult(false);
                }

            }

            return await Task.FromResult(true);
        }

        public async Task<List<CustomerDto>> GetCustomers()
        {
            List<CustomerDto> customers = null;
            Exception lastEx = null;
            using (nogaDBContext context = new nogaDBContext())
            {
                try
                {
                    customers = context.Customers.ToList().Select((c) =>
                    {
                        return new CustomerDto()
                        {
                            Name = c.Name,
                            IsDeleted = c.IsDeleted,
                            Created = c.Created,
                            CustomerNumber = c.CustomerNumber,
                            Addresses = context.Addresses.Where(a => a.CustomerId == c.Id).ToList()
                        };

                    })
                      .ToList();
                }
                catch (Exception ex)
                {
                    this.log.LogError(ex, "failed to fetch customers");
                    lastEx = ex;
                }
                return customers;


            }
        }
    }
}
