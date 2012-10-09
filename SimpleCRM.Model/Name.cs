using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SimpleCRM.Model
{
    public class Name
    {

        [MaxLength(255)]
        public string Prefix { get; set; }

        [MaxLength(255)]
        public string First { get; set; }

        [MaxLength(255)]
        public string Middle { get; set; }

        [MaxLength(255)]
        public string Last { get; set; }

        [MaxLength(255)]
        public string Suffix { get; set; }
    }
}
