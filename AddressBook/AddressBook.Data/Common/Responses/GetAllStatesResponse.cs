using AddressBook.Data.Common.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AddressBook.Data.Common.Responses
{
  [DataContract]
  public class GetAllStatesResponse : Response
  {
    [DataMember(Name = "States", IsRequired = true)]
    public List<StateRecord> States;
  }
}