using AddressBook.Data;
using AddressBook.Data.Common.Records;
using AddressBook.Data.Common.Requests;
using AddressBook.Data.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressBook.Data.ServiceCommands
{
  public class UpdatePersonServiceCommand : ServiceCommand<UpdatePersonRequest, UpdatePersonResponse>
  {
    private UpdatePersonRequest _request;

    protected override bool OnExecute(UpdatePersonResponse response)
    {
      PersonRecord personRecord = _request.PersonRecord;
      Person person = Providers.Data.People.Find(x => x.PersonIdentifier == _request.PersonRecord.PersonIdentifier);
      if (person != null)
      {
        var phoneRegex = new Regex("[^0-9]+");
        person.Name.FirstName = personRecord.Name.FirstName;
        person.Name.MiddleName = personRecord.Name.MiddleName;
        person.Name.LastName = personRecord.Name.LastName;
        person.Address.Street = personRecord.Address.Street;
        person.Address.City = personRecord.Address.City;
        person.Address.State = Providers.Data.States.Find(x => x.State1 == personRecord.Address.State);
        person.Address.Zip = personRecord.Address.Zip;
        person.Phone.Phone1 = phoneRegex.Replace(personRecord.Phone.PhoneNumber, string.Empty);
        person.Email.Email1 = personRecord.Email.Email;

        Providers.Data.People.Update(person);
        response.Status.IsSuccessful = true;
        return true;
      }
      else
      {
        response.Status.IsSuccessful = false;
        response.Status.ErrorMessage = string.Format("Could not find person with PersonIdentifier = {0}.", _request.PersonRecord.PersonIdentifier);
        return false;
      }
    }

    protected override void Validate(UpdatePersonRequest request)
    {
      if (request == null)
      {
        throw new Exception("The request must be set.");
      }
      if (request.PersonRecord == null)
      {
        throw new Exception("PersonRecord must be set.");
      }
      if (string.IsNullOrWhiteSpace(request.PersonRecord.PersonIdentifier))
      {
        throw new Exception("PersonRecord.PersonIdentifier must be set.");
      }

      request.PersonRecord.Name.Validate();
      request.PersonRecord.Address.Validate();
      request.PersonRecord.Phone.Validate();
      request.PersonRecord.Email.Validate();

      _request = request;
    }
  }
}
