using employeeManager.API.Models;
using employeeManager.Models;
using employeeManager.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata;
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

        public async Task<bool> IsCustomerExist(string customerNumber)
        {
            using (nogaDBContext context = new nogaDBContext())
            {
                var c = await context.Customers.FirstOrDefaultAsync(x => x.CustomerNumber == customerNumber);
                if (c == null)
                    return false;
            }
            return true;
        }
        public async Task<bool> CreateNewCustomer(CustomerRequest req)
        {
            if (req == null)
            {
                this.log.LogError("req parameter is empty");
                return false;
            }

            var customer = new Customer()
            {
                IsDeleted = false,
                Created = DateTime.Now,
                CustomerNumber = req.CustomerNumber,
                Id = Nanoid.Nanoid.Generate(),
                Name = req.Name
            };

            var contacts = req.Contacts.Select(x =>
            {
                return new Contact()
                {
                    Created = DateTime.Now,
                    IsDeleted = false,
                    CustomerId = customer.Id,
                    Email = x.Email,
                    FullName = x.FullName,
                    Id = Nanoid.Nanoid.Generate(),
                    OfficeNumber = x.OfficeNumber
                };

            }).ToList();

            var addresses = req.Addresses.Select(x =>
            {
                return new Address()
                {
                    Created = DateTime.Now,
                    IsDeleted = false,
                    City = x.City,
                    Street = x.Street,
                    CustomerId = customer.Id,
                    Id = Nanoid.Nanoid.Generate()
                };

            }).ToList();
            using (nogaDBContext context = new nogaDBContext())
            {
                try
                {
                    await context.Customers.AddAsync(customer);
                    await context.Contacts.AddRangeAsync(contacts);
                    await context.Addresses.AddRangeAsync(addresses);
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

        public async Task<DetailedCustomer> GetCustomer(string id)
        {
            DetailedCustomer customer = null;

            using (nogaDBContext context = new nogaDBContext())
            {
                try
                {
                    var c = context.Customers.FirstOrDefault(x => x.Id == id);
                    if (c == null) throw new Exception($"did not find this customer by id: {id}");
                    customer = new DetailedCustomer()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        IsDeleted = c.IsDeleted,
                        Created = c.Created,
                        CustomerNumber = c.CustomerNumber,
                        Addresses = context.Addresses.Where(a => a.CustomerId == c.Id).ToList(),
                        Contacts = context.Contacts.Where(x => x.CustomerId == c.Id).ToList()
                    };
                }
                catch (Exception ex)
                {
                    this.log.LogError(ex, $"failed to fetch customer from DB");
                }

            }
            return customer;
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
                            Id = c.Id,
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
        public async Task<bool> DeleteAddress(string id)
        {
            using (nogaDBContext context = new nogaDBContext())
            {
                try
                {
                    var entity = await context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
                    if (entity == null)
                        return true;
                    entity.IsDeleted = true;
                    context.Addresses.Update(entity);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    this.log.LogError(ex, $"failed to delete record of Address. Address Id: {id}");
                    return false;
                }
                return true;
            }
        }
        public async Task<bool> UpdateAddress(AddressRequest address)
        {
            using (nogaDBContext context = new nogaDBContext())
            {
                try
                {
                    var addressEntity = await context.Addresses.FirstOrDefaultAsync(x => x.Id == address.Id);
                    addressEntity.City = address.City;
                    addressEntity.Street = address.Street;
                    context.Addresses.Update(addressEntity);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    this.log.LogError(ex, $"failed to update address.");
                    return false;
                }
                return true;
            }
        }
        public async Task<bool> UpdateContact(ContactRequest contact)
        {
            using (nogaDBContext context = new nogaDBContext())
            {
                try
                {
                    var contactEntity = await context.Contacts.FirstOrDefaultAsync(x => x.Id == contact.Id);
                    contactEntity.FullName = contact.FullName;
                    contactEntity.Email = contact.Email;
                    contactEntity.OfficeNumber = contact.OfficeNumber;
                    context.Contacts.Update(contactEntity);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    this.log.LogError(ex, $"failed to update contact. contactId : {contact.Id}");
                    return false;
                }
                return true;
            }
        }
        public async Task<bool> UpdateCustomer(CustomerRequest customer)
        {
            using (nogaDBContext context = new nogaDBContext())
            {
                try
                {
                    var customerEntity = await context.Customers.FirstOrDefaultAsync(x => x.Id == customer.Id);
                    customerEntity.Name = customer.Name;
                    customerEntity.CustomerNumber = customer.CustomerNumber;
                    context.Customers.Update(customerEntity);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    this.log.LogError(ex, $"failed to update customer. customerId : {customer.Id}");
                    return false;
                }
                return true;
            }

        }
        public async Task<bool> DeleteContact(string id)
        {
            using (nogaDBContext context = new nogaDBContext())
            {
                try
                {
                    var entity = await context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
                    if (entity == null)
                        return true;
                    entity.IsDeleted = true;
                    context.Contacts.Update(entity);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    this.log.LogError(ex, $"failed to delete record of contact.  contactId: {id}");
                    return false;
                }
                return true;
            }
        }
        public async Task<bool> DeleteCustomer(string id)
        {
            using (nogaDBContext context = new nogaDBContext())
            {
                try
                {
                    var entity = await context.Customers.FirstOrDefaultAsync(x => x.Id == id);
                    if (entity == null)
                        return true;
                    entity.IsDeleted = true;
                    context.Customers.Update(entity);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    this.log.LogError(ex, $"failed to delete record of customer.  customerId: {id}");
                    return false;
                }
                return true;
            }
        }



        //TODO: compete this implemenation to make a general delete, update function to all entites
        //public async Task<bool> DeleteRecord<T>(string id) where T: IEntity
        //{
        //    var tt = Activator.CreateInstance<T>();
        //    await tt.DeleteRecord(id);

        //}
    }
}
