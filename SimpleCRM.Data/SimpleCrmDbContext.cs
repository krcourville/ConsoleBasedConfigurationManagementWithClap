using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SimpleCRM.Model;

namespace SimpleCRM.Data
{
    public class SimpleCrmDbContext:DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Activity> Activities { get; set; }
    }
}
