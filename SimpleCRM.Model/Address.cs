using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SimpleCRM.Model
{
    [ComplexType]
    public class Address
    {
        [MaxLength(255)]
        public string Street1 { get; set; }

        [MaxLength(255)]
        public string Street2 { get; set; }

        [MaxLength(255)]
        public string City { get; set; }

        [MaxLength(2)]
        public string StateOrProvince { get; set; }

        [MaxLength(10)]
        public string PostalCode { get; set; }

        [MaxLength(255)]
        public string Country { get; set; }

    }
}
