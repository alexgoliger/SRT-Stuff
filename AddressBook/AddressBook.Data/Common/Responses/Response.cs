using AddressBook.Data.ServiceCommands;
using System;
using System.Runtime.Serialization;

namespace AddressBook.Data.Common.Responses
{
  [DataContract]
  public class Response : IResponse
  {
    [DataMember(Name = "Status", IsRequired = true)]
    public Status Status { get; set; }
  }
}