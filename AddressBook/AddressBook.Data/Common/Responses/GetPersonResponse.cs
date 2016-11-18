using AddressBook.Data.Common.Records;
using System.Runtime.Serialization;

namespace AddressBook.Data.Common.Responses
{
  [DataContract]
  public class GetPersonResponse : Response
  {
    [DataMember(Name = "Person", IsRequired = true)]
    public PersonRecord Person { get; set; }
  }
}