using AddressBook.Data;
using AddressBook.Data.Common.Records;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AddressBook.Data.Repository
{
  public class StateRepository : Repository<AddressBookEntities, State, int>
  {
    public StateRepository(Guid callToken, AddressBookEntities entities) : base(callToken, entities)
    {
    }

    protected override DbSet<State> DbSet
    {
      get
      {
        return Context.States;
      }
    }
  }
}