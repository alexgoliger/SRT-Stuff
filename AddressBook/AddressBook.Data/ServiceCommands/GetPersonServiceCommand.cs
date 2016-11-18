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
  public class GetPersonServiceCommand : ServiceCommand<GetPersonRequest, GetPersonResponse>
  {
    private GetPersonRequest _request;

    protected override bool OnExecute(GetPersonResponse response)
    {
      Person person = Providers.Data.People.Find(x => x.PersonIdentifier == _request.PersonIdentifier);
      PersonRecord personRecord = null;

      if (person != null)
      {
        personRecord = new PersonRecord
        {
          Name = new NameRecord
          {
            FirstName = person.Name.FirstName,
            MiddleName = person.Name.MiddleName,
            LastName = person.Name.LastName
          },
          Address = new AddressRecord
          {
            Street = person.Address.Street,
            City = person.Address.City,
            State = person.Address.State.State1,
            Zip = person.Address.Zip
          },
          Phone = new PhoneRecord
          {
            PhoneNumber = person.Phone.Phone1
          },
          Email = new EmailRecord
          {
            Email = person.Email.Email1
          },
          PersonIdentifier = person.PersonIdentifier
        };
      }

      response.Person = personRecord;
      if (response.Person == null)
      {
        response.Status.IsSuccessful = false;
        response.Status.ErrorMessage = string.Format("Could not find person with PersonIdentifier = {0}", _request.PersonIdentifier);
        return false;
      }
      else
      {
        response.Person.Validate();
        response.Status.IsSuccessful = true;
        return true;
      }
    }

    protected override void Validate(GetPersonRequest request)
    {
      if (request == null)
      {
        throw new Exception("The request must be set.");
      }

      if (string.IsNullOrWhiteSpace(request.PersonIdentifier))
      {
        throw new Exception("PersonIdentifier is required.");
      }

      _request = request;
    }
  }
}
