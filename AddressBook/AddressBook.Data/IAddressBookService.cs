using AddressBook.Data.Common.Requests;
using AddressBook.Data.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AddressBook.Data
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAddressBookService" in both code and config file together.
  [ServiceContract]
  public interface IAddressBookService
  {
    [OperationContract]
    GetAllStatesResponse GetAllStates(GetAllStatesRequest request);

    [OperationContract]
    GetAllPeopleResponse GetAllPeople(GetAllPeopleRequest request);

    [OperationContract]
    AddPersonResponse AddPerson(AddPersonRequest request);

    [OperationContract]
    DeletePeopleResponse DeletePeople(DeletePeopleRequest request);

    [OperationContract]
    GetPersonResponse GetPerson(GetPersonRequest request);

    [OperationContract]
    UpdatePersonResponse UpdatePerson(UpdatePersonRequest request);
  }
}
