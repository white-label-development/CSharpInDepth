using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Experience { get; set; }

        public decimal Salary { get; set; }

        public Address Address { get; set; }

        public AComplexType ComplexType { get; set; }

        public string Prop1 { get; set; } // will map to a complex type in dest
        public string Prop2 { get; set; }

        public System.Guid Id { get; set; }
    }

    public class Address
    {
        public string City { get; set; }
    }


    public class AComplexType
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
        public string Baz { get; set; }
    }
}
