using System;
using System.Collections.Generic;

#nullable disable

namespace employeeManager.Models.DB
{
    public partial class Customer
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public string CustomerNumber { get; set; }
    }
}
