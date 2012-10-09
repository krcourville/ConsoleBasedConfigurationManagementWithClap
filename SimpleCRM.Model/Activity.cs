using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SimpleCRM.Model
{
    public class Activity
    {
        public Activity()
        {
            TimeCreated = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public string Subject { get; set; }

        public string Body { get; set; }

        public virtual Contact Contact { get; set; }

        [Required]
        public DateTime? TimeCreated { get; set; }

        [ForeignKey("Contact")]
        public int? Contact_Id { get; set; }
    }
}
