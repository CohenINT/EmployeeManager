using System;
using System.Collections.Generic;

#nullable disable

namespace employeeManager.Models.DB
{
    public partial class Address
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string CustomerId { get; set; }
    }
}
