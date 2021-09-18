using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace automapper_fun.Models
{
    public class DeveloperDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Experience { get; set; }

        public decimal Compensation { get; set; }
        public bool IsEmployed { get; set; }

        public string FooPrimitiveTypeFromComplexType { get; set; }

        public AddressDto Address { get; set; }

        public ComplexTypeDto ComplexType { get; set; }


        public System.Guid Id { get; set; }
    }

    public class AddressDto
    {
        public string City { get; set; }
    }

    public class ComplexTypeDto
    {
        public string Prop1 { get; set; } 
        public string Prop2 { get; set; }
    }
}
