using AddressBook.Data.Common.Requests;
using AddressBook.Data.Common.Responses;
using AddressBook.Data.ServiceCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AddressBook.Data
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AddressBookService" in code, svc and config file together.
  // NOTE: In order to launch WCF Test Client for testing this service, please select AddressBookService.svc or AddressBookService.svc.cs at the Solution Explorer and start debugging.
  public class AddressBookService : IAddressBookService
  {
    public GetAllStatesResponse GetAllStates(GetAllStatesRequest request)
    {
      var command = new GetAllStatesServiceCommand();
      return command.Execute(request);
    }

    public GetAllPeopleResponse GetAllPeople(GetAllPeopleRequest request)
    {
      var command = new GetAllPeopleServiceCommand();
      return command.Execute(request);
    }

    public AddPersonResponse AddPerson(AddPersonRequest request)
    {
      var command = new AddPersonServiceCommand();
      return command.Execute(request);
    }

    public DeletePeopleResponse DeletePeople(DeletePeopleRequest request)
    {
      var command = new DeletePeopleServiceCommand();
      return command.Execute(request);
    }

    public GetPersonResponse GetPerson(GetPersonRequest request)
    {
      var command = new GetPersonServiceCommand();
      return command.Execute(request);
    }

    public UpdatePersonResponse UpdatePerson(UpdatePersonRequest request)
    {
      var command = new UpdatePersonServiceCommand();
      return command.Execute(request);
    }
  }
}
