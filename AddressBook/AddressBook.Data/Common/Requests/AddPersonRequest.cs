using AddressBook.Data.Common.Records;
using System.Runtime.Serialization;

namespace AddressBook.Data.Common.Requests
{
  [DataContract]
  public class AddPersonRequest : Request
  {
    [DataMember(Name = "Person", IsRequired = false)]
    public PersonRecord Person { get; set; }
  }
}
