using employeeManager.API.Models;
using employeeManager.Models;
using employeeManager.Models.DB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employeeManager.Services
{
    public interface ICustomerService
    {
        public Task<List<CustomerDto>> GetCustomers();
        public Task<bool> CreateNewCustomer(CustomerRequest req);
        public Task<DetailedCustomer> GetCustomer(string id);
        public Task<bool> UpdateAddress(AddressRequest address);
        public Task<bool> DeleteAddress(string id);
        public Task<bool> UpdateContact(ContactRequest contact);
        public Task<bool> DeleteContact(string id);
        public Task<bool> IsCustomerExist(string customerNumber);
        public Task<bool> DeleteCustomer(string id);
        public Task<bool> UpdateCustomer(CustomerRequest customer);
    }
}