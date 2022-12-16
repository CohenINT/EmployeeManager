using employeeManager.Models.DB;
using System;
using System.Collections.Generic;

namespace employeeManager.API.Models
{
    public class AddressRequest
    {
        public string Id { set; get; }
        public string City { set; get; }
        public string Street { set; get; }
    }

    public class ContactRequest
    {
        public string Id { set; get; }
        public string FullName { set; get; }
        public string Email { set; get; }
        public string OfficeNumber { set; get; }

    }

    public class CustomerRequest
    {
        public string Id { set; get; }
        public DateTime Created { set; get; }
        public bool IsDeleted { set; get; }
        public string Name { set; get; }
        public string CustomerNumber { set; get; }
        public List<Contact> Contacts { set; get; }
        public List<Address> Addresses { set; get; }
    }
}
