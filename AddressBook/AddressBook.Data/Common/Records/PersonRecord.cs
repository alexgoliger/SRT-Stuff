using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AddressBook.Data.Common.Records
{
  [DataContract]
  public class PersonRecord : Record
  {
    [DataMember(Name = "PersonIdentifier", IsRequired = true)]
    public string PersonIdentifier { get; set; }
    [DataMember(Name = "Name", IsRequired = true)]
    public NameRecord Name { get; set; }
    [DataMember(Name = "Address", IsRequired = true)]
    public AddressRecord Address { get; set; }
    [DataMember(Name = "Phone", IsRequired = true)]
    public PhoneRecord Phone { get; set; }
    [DataMember(Name = "Email", IsRequired = true)]
    public EmailRecord Email { get; set; }
  }
}