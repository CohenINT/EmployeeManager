using System;
using System.Collections.Generic;

#nullable disable

namespace employeeManager.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public string CustomerNumber { get; set; }
    }
}
