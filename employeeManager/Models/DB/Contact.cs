using System;
using System.Collections.Generic;

#nullable disable

namespace employeeManager.Models.DB
{
    public partial class Contact
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public string FullName { get; set; }
        public string OfficeNumber { get; set; }
        public string Email { get; set; }
        public string CustomerId { get; set; }
    }
}
