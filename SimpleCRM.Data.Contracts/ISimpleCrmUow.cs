using SimpleCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCRM.Data.Contracts
{
    public interface ISimpleCrmUow : IDisposable
    {
        // Save pending changes to the data store.
        void Commit();

        // Repositories
        IRepository<Contact> Contacts { get; }
    }
}
