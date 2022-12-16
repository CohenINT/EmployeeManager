using employeeManager.Models.DB;
using System;
using System.Collections.Generic;

namespace employeeManager.Models
{

    //General detail for presenting customers list in a table.
    public class CustomerDto
    {
        public string Name { set; get; }
        public bool IsDeleted { set; get; }
        public DateTimeOffset Created { set; get; }
        public string CustomerNumber { set; get; }
        public List<Address> Addresses { set; get; }

    }

   
}
