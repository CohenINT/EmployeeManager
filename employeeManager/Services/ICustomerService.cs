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
        public Task<bool> CreateNewCustomer(Customer customer, List<Contact> contacts);
        public Task<DetailedCustomer> GetCustomer(string id);
        public Task<bool> UpdateAddress(AddressRequest address);
    }
}