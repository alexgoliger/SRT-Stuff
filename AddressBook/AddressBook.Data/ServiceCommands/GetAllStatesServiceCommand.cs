using AddressBook.Data.Common.Records;
using AddressBook.Data.Common.Requests;
using AddressBook.Data.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Data.ServiceCommands
{
  public class GetAllStatesServiceCommand : ServiceCommand<GetAllStatesRequest, GetAllStatesResponse>
  {
    protected override bool OnExecute(GetAllStatesResponse response)
    {
      List<StateRecord> states = (from s in Providers.Data.States.FindAll(x => true)
                                 select new StateRecord { StateIdentifier = s.StateIdentifier, State = s.State1 }).ToList();
      response.States = states;
      return true;
    }

    protected override void Validate(GetAllStatesRequest request)
    {
      if (request == null)
      {
        throw new Exception("The request must be set.");
      }
    }
  }
}