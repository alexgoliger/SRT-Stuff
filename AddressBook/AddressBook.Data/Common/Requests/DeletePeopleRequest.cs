using AddressBook.Data.Common.Records;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AddressBook.Data.Common.Requests
{
  [DataContract]
  public class DeletePeopleRequest : Request
  {
    [DataMember(Name = "PersonIdentifiers", IsRequired = false)]
    public List<string> PersonIdentifiers { get; set; }
  }
}
