using SimpleCRM.Data.Contracts;
using SimpleCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCRM.Data
{
    public class SimpleCrmUow : ISimpleCrmUow
    {
        public SimpleCrmUow(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        private SimpleCrmDbContext DbContext { get; set; }


        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        private void CreateDbContext()
        {
            DbContext = new SimpleCrmDbContext();

            // Do NOT enable proxied entities, else serialization fails
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            DbContext.Configuration.ValidateOnSaveEnabled = false;

            //DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public IRepository<Contact> Contacts
        {
            get { return GetStandardRepo<Contact>(); }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
                if (DbContext != null)
                    DbContext.Dispose();
        }
    }
}
