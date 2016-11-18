using AddressBook.Data.Common.Requests;
using AddressBook.Data.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.ServiceCommands
{
  public class DeleteNameServiceCommand : ServiceCommand<DeleteNameRequest, DeleteNameResponse>
  {
    private DeleteNameRequest _request;

    protected override bool OnExecute(DeleteNameResponse response)
    {
      //Providers.Data.Names.Delete(n => n.NameIdentifier == _request.NameIdentifier);
      return true;
    }

    protected override void Validate(DeleteNameRequest request)
    {
      if (request == null)
      {
        throw new Exception("The request must be set.");
      }
      if (string.IsNullOrWhiteSpace(request.NameIdentifier))
      {
        throw new Exception("The NameIdentifier in the request must be set.");
      }

      _request = request;
    }
  }
}
