using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyAdmin.Models
{
    public class Employee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Birthdate { get; set; }

        public string Department { get; set; }
    }
}