using AddressBook.Data;
using AddressBook.Data.Common.Records;
using AddressBook.Data.Common.Requests;
using AddressBook.Data.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.ServiceCommands
{
  public class DeletePeopleServiceCommand : ServiceCommand<DeletePeopleRequest, DeletePeopleResponse>
  {
    private DeletePeopleRequest _request;

    protected override bool OnExecute(DeletePeopleResponse response)
    {
      Providers.Data.People.DeleteAll(x => _request.PersonIdentifiers.Contains(x.PersonIdentifier));
      return true;
    }

    protected override void Validate(DeletePeopleRequest request)
    {
      if (request == null)
      {
        throw new Exception("The request must be set.");
      }
      if (request.PersonIdentifiers == null)
      {
        throw new Exception("The PersonIdentifiers in the request must be set.");
      }

      _request = request;
    }
  }
}
