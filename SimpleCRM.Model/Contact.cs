using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCRM.Model
{
    public class Contact
    {
        public int Id { get; set; }

        public Name Name { get; set; }

        public PhoneNumber HomePhone { get; set; }

        public PhoneNumber BusinessPhone { get; set; }

        public PhoneNumber MobilePhone { get; set; }

        public Address HomeAddress { get; set; }

        public Address BusinessAddress { get; set; }
    }
}
