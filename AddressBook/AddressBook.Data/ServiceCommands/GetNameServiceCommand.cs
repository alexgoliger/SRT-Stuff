using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Data.Repository;
using AddressBook.Data.Common.Requests;
using AddressBook.Data.Common.Responses;
using AddressBook.Data.Common.Records;
using AddressBook.Data;

namespace AddressBook.Data.ServiceCommands
{
  public class GetNameServiceCommand : ServiceCommand<GetNameRequest, GetNameResponse>
  {
    private GetNameRequest _request;

    protected override bool OnExecute(GetNameResponse response)
    {
      Name name = Providers.Data.Names.Find(n => n.NameIdentifier == _request.NameIdentifier);
      NameRecord nameRecord = null;

      if (name != null)
      {
        nameRecord = new NameRecord
        {
          NameIdentifier = name.NameIdentifier,
          FirstName = name.FirstName,
          MiddleName = name.MiddleName,
          LastName = name.LastName
        };
      }

      response.Name = nameRecord;
      if (response.Name == null)
      {
        response.Status.IsSuccessful = false;
        response.Status.ErrorMessage = string.Format("Could not find name with NameIdentifier = {0}", _request.NameIdentifier);
        return false;
      }
      else
      {
        response.Name.Validate();
        response.Status.IsSuccessful = true;
        return true;
      }
    }

    protected override void Validate(GetNameRequest request)
    {
      if (request == null)
      {
        throw new Exception("The request must be set.");
      }

      if (string.IsNullOrWhiteSpace(request.NameIdentifier))
      {
        throw new Exception("NameIdentifier is required.");
      }

      _request = request;
    }
  }
}
