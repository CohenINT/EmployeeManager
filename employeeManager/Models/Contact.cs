﻿using System;
using System.Collections.Generic;

#nullable disable

namespace employeeManager.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public string FullName { get; set; }
        public string OfficeNumber { get; set; }
        public string Email { get; set; }
        public int CustomerId { get; set; }
    }
}
