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
  public class UpdateNameServiceCommand : ServiceCommand<UpdateNameRequest, UpdateNameResponse>
  {
    private UpdateNameRequest _request;

    protected override bool OnExecute(UpdateNameResponse response)
    {
      NameRecord nameRecord = _request.NameRecord;
      Name name = Providers.Data.Names.Find(n => n.NameIdentifier == _request.NameRecord.NameIdentifier);
      if (name != null)
      {
        name.FirstName = nameRecord.FirstName;
        name.MiddleName = nameRecord.MiddleName;
        name.LastName = nameRecord.LastName;
        Providers.Data.Names.Update(name);
        response.Status.IsSuccessful = true;
        return true;
      }
      else
      {
        response.Status.IsSuccessful = false;
        response.Status.ErrorMessage = string.Format("Could not find name with NameIdentifier = {0}.", _request.NameRecord.NameIdentifier);
        return false;
      }
    }

    protected override void Validate(UpdateNameRequest request)
    {
      if (request == null)
      {
        throw new Exception("The request must be set.");
      }
      if (request.NameRecord == null)
      {
        throw new Exception("NameRecord must be set.");
      }
      if (string.IsNullOrWhiteSpace(request.NameRecord.NameIdentifier))
      {
        throw new Exception("NameRecord.NameIdentifier must be set.");
      }
      if (string.IsNullOrWhiteSpace(request.NameRecord.FirstName))
      {
        throw new Exception("NameRecord.FirstName must be set.");
      }
      if (string.IsNullOrWhiteSpace(request.NameRecord.LastName))
      {
        throw new Exception("NameRecord.LastName must be set.");
      }
      request.NameRecord.Validate();

      _request = request;
    }
  }
}
