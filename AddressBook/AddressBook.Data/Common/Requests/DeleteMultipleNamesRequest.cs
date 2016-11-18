using AddressBook.Data.Common.Records;
using System.Runtime.Serialization;

namespace AddressBook.Data.Common.Requests
{
  [DataContract]
  public class DeleteMultipleNamesRequest : Request
  {
    [DataMember(Name = "NameRecord", IsRequired = false)]
    public NameRecord NameRecord { get; set; }
  }
}
