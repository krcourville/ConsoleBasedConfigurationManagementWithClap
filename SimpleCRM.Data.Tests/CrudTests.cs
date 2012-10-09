using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCRM.Model;
using SimpleCRM.Data.Contracts;
using FluentAssertions;

namespace SimpleCRM.Data.Tests
{
    [TestClass]
    public class CrudTests
    {
        [ClassInitialize]
        public static void TestInitialize(TestContext testContext)
        {
            var ctx = new SimpleCrmDbContext();
            if (ctx.Database.Exists())
                ctx.Database.Delete();
        }

        [TestMethod]
        public void CanCrudContact()
        {
            const string firstName1 = "John";
            const string lastName1 = "Smith";
            const string firstName2 = "Johnathon";
            const string lastName2 = "Smithen";
            //
            // C
            var contact = DoDataWork(uow =>
                uow.Contacts.Add(new Contact
                {
                    Name = new Name
                    {
                        First = firstName1,
                        Last = lastName1
                    }
                }
            ));
            
            contact.Should().NotBeNull();
            contact.Id.Should().BeGreaterThan(0);
            contact.Name.First.Should().Be(firstName1);
            contact.Name.Last.Should().Be(lastName1);
            //
            // r
            contact = DoDataWork(uow => uow.Contacts.GetById(contact.Id));
            contact.Should().NotBeNull();

            var contactId = contact.Id;
            //
            // u
            contact.Name.First = firstName2;
            contact.Name.Last = lastName2;
            DoDataWork(uow => uow.Contacts.Update(contact));

            contact = DoDataWork(uow => uow.Contacts.GetById(contact.Id));

            contact.Should().NotBeNull();
            contact.Name.First.Should().Be(firstName2);
            contact.Name.Last.Should().Be(lastName2);
            //
            // d
            DoDataWork(uow => uow.Contacts.Delete(contactId));
            contact = DoDataWork(uow => uow.Contacts.GetById(contact.Id));
            contact.Should().BeNull();


        }

        private void DoDataWork(Action<ISimpleCrmUow> operation, bool withAutoCommit = true)
        {
            var factories = new RepositoryFactories();
            IRepositoryProvider provider = new RepositoryProvider(factories);

            using (ISimpleCrmUow uow = new SimpleCrmUow(provider))
            {
                operation(uow);

                if (withAutoCommit)
                    uow.Commit();
            }
        }


        private T DoDataWork<T>(Func<ISimpleCrmUow, T> operation, bool withAutoCommit = true)
        {
            var factories = new RepositoryFactories();
            IRepositoryProvider provider = new RepositoryProvider(factories);
            using (ISimpleCrmUow uow = new SimpleCrmUow(provider))
            {
                var result = operation(uow);

                if (withAutoCommit)
                    uow.Commit();

                return result;
            }
        }
    }
}
