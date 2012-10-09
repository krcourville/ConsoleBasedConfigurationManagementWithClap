using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SimpleCRM.Model
{
    public class Contact
    {
        public Contact()
        {
            HomeAddress = new Address();
            BusinessAddress = new Address();
            Activities = new List<Activity>();
        }

        public int Id { get; set; }

        public Name Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string HomePhone { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string BusinessPhone { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }

        public Address HomeAddress { get; set; }

        public Address BusinessAddress { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}
