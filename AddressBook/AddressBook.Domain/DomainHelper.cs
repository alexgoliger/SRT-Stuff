using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Domain.AddressBookServiceReference;
using AddressBook.Domain.DTO;

namespace AddressBook.Domain
{
  public static class DomainHelper
  {
    private const string DEFAULT_HEADER = "CallerName = AddressBook.Domain";
    private static AddressBookServiceClient _service;

    static DomainHelper()
    {
      _service = new AddressBookServiceClient();
      _service.InnerChannel.OperationTimeout = new TimeSpan(0, 10, 0);
    }

    public static List<StateRecord> GetAllStates()
    {
      return _service.GetAllStates(new GetAllStatesRequest { Header = DEFAULT_HEADER }).States;
    }

    public static List<PersonRecord> GetAllContacts()
    {
      return _service.GetAllPeople(new GetAllPeopleRequest { Header = DEFAULT_HEADER }).People;
    }

    public static string TryAddNewContact(ContactDTO contact, out List<string> errors)
    {
      var person = new PersonRecord
      {
        Name = new NameRecord
        {
          FirstName = contact.FirstName,
          MiddleName = contact.MiddleName,
          LastName = contact.LastName
        },
        Address = new AddressRecord
        {
          Street = contact.Street,
          City = contact.City,
          State = contact.State,
          Zip = contact.Zip
        },
        Phone = new PhoneRecord
        {
          Phone = contact.Phone
        },
        Email = new EmailRecord
        {
          Email = contact.Email
        }
      };

      var response = _service.AddPerson(new AddPersonRequest { Header = DEFAULT_HEADER, Person = person });
      if (!response.Status.IsSuccessful)
      {
        errors = new List<string> { response.Status.ErrorMessage };
        return null;
      }
      else
      {
        errors = new List<string>();
        return response.PersonIdentifier;
      }
    }

    public static void RemoveContacts(List<string> personIdentifiers)
    {
      _service.DeletePeople(new DeletePeopleRequest { Header = DEFAULT_HEADER, PersonIdentifiers = personIdentifiers });
    }

    public static ContactDTO GetPerson(string personIdentifier)
    {
      var person = _service.GetPerson(new GetPersonRequest { Header = DEFAULT_HEADER, PersonIdentifier = personIdentifier }).Person;
      if (person != null)
      {
        return new ContactDTO
        {
          PersonIdentifier = person.PersonIdentifier,
          FirstName = person.Name.FirstName,
          MiddleName = person.Name.MiddleName,
          LastName = person.Name.LastName,
          Street = person.Address.Street,
          City = person.Address.City,
          State = person.Address.State,
          Zip = person.Address.Zip,
          Phone = person.Phone.Phone,
          Email = person.Email.Email
        };
      }
      else
      {
        return null;
      }
    }

    public static bool TryUpdateContact(ContactDTO contact, out List<string> errors)
    {
      var person = new PersonRecord
      {
        Name = new NameRecord
        {
          FirstName = contact.FirstName,
          MiddleName = contact.MiddleName,
          LastName = contact.LastName
        },
        Address = new AddressRecord
        {
          Street = contact.Street,
          City = contact.City,
          State = contact.State,
          Zip = contact.Zip
        },
        Phone = new PhoneRecord
        {
          Phone = contact.Phone
        },
        Email = new EmailRecord
        {
          Email = contact.Email
        },
        PersonIdentifier = contact.PersonIdentifier
      };

      var response = _service.UpdatePerson(new UpdatePersonRequest { Header = DEFAULT_HEADER, PersonRecord = person });
      if (!response.Status.IsSuccessful)
      {
        errors = new List<string> { response.Status.ErrorMessage };
        return false;
      }
      else
      {
        errors = new List<string>();
        return true;
      }
    }
  }
}
