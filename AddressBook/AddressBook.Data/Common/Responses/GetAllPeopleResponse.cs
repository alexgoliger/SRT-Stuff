using AddressBook.Data.Common.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AddressBook.Data.Common.Responses
{
  [DataContract]
  public class GetAllPeopleResponse : Response
  {
    [DataMember(Name = "People", IsRequired = true)]
    public List<PersonRecord> People;
  }
}