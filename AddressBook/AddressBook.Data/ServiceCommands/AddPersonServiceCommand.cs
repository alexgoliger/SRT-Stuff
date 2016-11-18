using AddressBook.Data.Common.Records;
using AddressBook.Data.Common.Requests;
using AddressBook.Data.Common.Responses;
using AddressBook.Data.Identifiers;
using System;
using System.Text.RegularExpressions;

namespace AddressBook.Data.ServiceCommands
{
  public class AddPersonServiceCommand : ServiceCommand<AddPersonRequest, AddPersonResponse>
  {
    private AddPersonRequest _request;

    protected override bool OnExecute(AddPersonResponse response)
    {
      var name = new Name
      {
        FirstName = _request.Person.Name.FirstName,
        MiddleName = _request.Person.Name.MiddleName,
        LastName = _request.Person.Name.LastName
      };
      var state = Providers.Data.States.Find(x => x.State1 == _request.Person.Address.State);
      var address = new Address
      {
        Street = _request.Person.Address.Street,
        City = _request.Person.Address.City,
        StateID = state.StateID,
        Zip = _request.Person.Address.Zip
      };
      var phoneRegex = new Regex("[^0-9]+");
      var phoneEntry = phoneRegex.Replace(_request.Person.Phone.PhoneNumber, string.Empty);
      var phone = new Phone
      {
        Phone1 = phoneEntry
      };
      var email = new Email
      {
        Email1 = _request.Person.Email.Email
      };
      
      Providers.Data.Names.Add(name);
      Providers.Data.Addresses.Add(address);
      Providers.Data.Phones.Add(phone);
      Providers.Data.Emails.Add(email);

      var person = new Person { NameID = name.NameID, AddressID = address.AddressID, PhoneID = phone.PhoneID, EmailID = email.EmailID };
      Providers.Data.People.Add(person);
      person.PersonIdentifier = new PersonIdentifier(person.PersonID).DisplayableIdentifier;
      Providers.Data.People.Update(person);
      response.PersonIdentifier = person.PersonIdentifier;
      return true;
    }

    protected override void Validate(AddPersonRequest request)
    {
      if (request == null)
      {
        throw new Exception("The request must be set.");
      }
      if (request.Person == null)
      {
        throw new Exception("The NameRecord in the request must be set.");
      }
      request.Person.Name.Validate();
      request.Person.Address.Validate();
      request.Person.Phone.Validate();
      request.Person.Email.Validate();

      _request = request;
    }
  }
}
