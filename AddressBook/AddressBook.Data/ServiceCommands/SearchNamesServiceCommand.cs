using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Data.Common.Requests;
using AddressBook.Data.Common.Responses;
using System.Linq.Expressions;
using AddressBook.Data.Common.Records;
using AddressBook.Data;

namespace AddressBook.Data.ServiceCommands
{
  public class SearchNamesServiceCommand : ServiceCommand<SearchNamesRequest, SearchNamesResponse>
  {
    private SearchNamesRequest _request;

    protected override bool OnExecute(SearchNamesResponse response)
    {
      NameRecord nameRecord = _request.NameRecord;
      bool nameIdentifierInCondition = !string.IsNullOrWhiteSpace(nameRecord.NameIdentifier);
      bool firstNameInCondition = !string.IsNullOrWhiteSpace(nameRecord.FirstName);
      bool middleNameInCondition = !string.IsNullOrWhiteSpace(nameRecord.MiddleName);
      bool lastNameInCondition = !string.IsNullOrWhiteSpace(nameRecord.LastName);
      Func<Name, bool> condition = n => (nameIdentifierInCondition ? n.NameIdentifier == nameRecord.NameIdentifier : true)
                                        && (firstNameInCondition ? n.FirstName == nameRecord.FirstName : true)
                                        && (middleNameInCondition ? n.MiddleName == nameRecord.MiddleName : true)
                                        && (lastNameInCondition ? n.LastName == nameRecord.LastName : true);

      response.Names = Providers.Data.Names.FindAll(condition);
      return true;
    }

    protected override void Validate(SearchNamesRequest request)
    {
      if (request == null)
      {
        throw new Exception("The request must be set.");
      }
      if (request.NameRecord == null)
      {
        throw new Exception("The NameRecord in the request must be set.");
      }
      _request = request;
    }
  }
}
