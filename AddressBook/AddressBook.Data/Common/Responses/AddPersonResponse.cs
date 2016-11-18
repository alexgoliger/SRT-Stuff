using System.Runtime.Serialization;

namespace AddressBook.Data.Common.Responses
{
  [DataContract]
  public class AddPersonResponse : Response
  {
    [DataMember(Name = "PersonIdentifier", IsRequired = true)]
    public string PersonIdentifier { get; set; }
  }
}
