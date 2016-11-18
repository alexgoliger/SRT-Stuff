using System;
using System.Runtime.Serialization;

namespace AddressBook.Data.Common.Requests
{
  [DataContract]
  public class GetPersonRequest : Request
  {
    [DataMember(Name = "PersonIdentifier", IsRequired = true)]
    public string PersonIdentifier { get; set; }
  }
}