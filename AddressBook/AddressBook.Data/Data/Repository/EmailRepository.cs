using AddressBook.Data;
using AddressBook.Data.Common.Records;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AddressBook.Data.Repository
{
  public class EmailRepository : Repository<AddressBookEntities, Email, int>
  {
    public EmailRepository(Guid callToken, AddressBookEntities entities) : base(callToken, entities)
    {
    }

    protected override DbSet<Email> DbSet
    {
      get
      {
        return Context.Emails;
      }
    }
  }
}