using System;
using System.Runtime.Serialization;

namespace AddressBook.Data.Common.Requests
{
  [DataContract]
  public class GetNameRequest : Request
  {
    [DataMember(Name = "NameIdentifier", IsRequired = true)]
    public string NameIdentifier { get; set; }
  }
}