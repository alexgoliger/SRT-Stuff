using AddressBook.Data;
using AddressBook.Data.Common.Records;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AddressBook.Data.Repository
{
  public class AddressRepository : Repository<AddressBookEntities, Address, int>
  {
    public AddressRepository(Guid callToken, AddressBookEntities entities) : base(callToken, entities)
    {
    }

    protected override DbSet<Address> DbSet
    {
      get
      {
        return Context.Addresses;
      }
    }
  }
}