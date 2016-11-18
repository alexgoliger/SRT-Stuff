using AddressBook.Data;
using AddressBook.Data.Common.Records;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AddressBook.Data.Repository
{
  public class NameRepository : Repository<AddressBookEntities, Name, int>
  {
    public NameRepository(Guid callToken, AddressBookEntities entities) : base(callToken, entities)
    {
    }

    protected override DbSet<Name> DbSet
    {
      get
      {
        return Context.Names;
      }
    }
  }
}