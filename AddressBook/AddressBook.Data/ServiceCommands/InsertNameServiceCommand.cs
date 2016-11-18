using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Data.Common.Requests;
using AddressBook.Data.Common.Responses;
using AddressBook.Data.Common.Records;
using AddressBook.Data.Identifiers;
using AddressBook.Data;

namespace AddressBook.Data.ServiceCommands
{
  public class InsertNameServiceCommand : ServiceCommand<InsertNameRequest, InsertNameResponse>
  {
    private InsertNameRequest _request;

    protected override bool OnExecute(InsertNameResponse response)
    {
      NameRecord nameRecord = _request.NameRecord;
      Name name = new Name
      {
        FirstName = nameRecord.FirstName,
        MiddleName = nameRecord.MiddleName,
        LastName = nameRecord.LastName
      };

      Providers.Data.Names.Add(name);
      NameIdentifier identifier = new NameIdentifier(name.NameID);
      name.NameIdentifier = identifier.DisplayableIdentifier;
      Providers.Data.Names.Update(name);

      response.NameIdentifier = name.NameIdentifier;
      return true;
    }

    protected override void Validate(InsertNameRequest request)
    {
      if (request == null)
      {
        throw new Exception("The request must be set.");
      }
      if (request.NameRecord == null)
      {
        throw new Exception("NameRecord must be set.");
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
