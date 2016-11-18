using AddressBook.Data.Common.Records;
using AddressBook.Data.Common.Requests;
using AddressBook.Data.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Data.ServiceCommands
{
  public class GetAllPeopleServiceCommand : ServiceCommand<GetAllPeopleRequest, GetAllPeopleResponse>
  {
    protected override bool OnExecute(GetAllPeopleResponse response)
    {
      var people = (from person in Providers.Data.People.FindAll(x => true)
                    select new PersonRecord
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
                    }).ToList();

      response.People = people;
      return true;
    }

    protected override void Validate(GetAllPeopleRequest request)
    {
      if (request == null)
      {
        throw new Exception("The request must be set.");
      }
    }
  }
}