using AddressBook.Data;
using AddressBook.Data.Common.Records;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AddressBook.Data.Repository
{
  public class PersonRepository : Repository<AddressBookEntities, Person, int>
  {
    public PersonRepository(Guid callToken, AddressBookEntities entities) : base(callToken, entities)
    {
    }

    protected override DbSet<Person> DbSet
    {
      get
      {
        return Context.People;
      }
    }
  }
}