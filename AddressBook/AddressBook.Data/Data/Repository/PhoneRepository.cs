using AddressBook.Data;
using AddressBook.Data.Common.Records;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AddressBook.Data.Repository
{
  public class PhoneRepository : Repository<AddressBookEntities, Phone, int>
  {
    public PhoneRepository(Guid callToken, AddressBookEntities entities) : base(callToken, entities)
    {
    }

    protected override DbSet<Phone> DbSet
    {
      get
      {
        return Context.Phones;
      }
    }
  }
}