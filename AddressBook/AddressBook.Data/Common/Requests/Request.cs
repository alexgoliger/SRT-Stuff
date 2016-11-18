using System.Runtime.Serialization;

namespace AddressBook.Data.Common.Requests
{
  [DataContract]
  public abstract class Request : IRequest
  {
    [DataMember(Name = "Header")]
    public string Header { get; set; }
  }
}