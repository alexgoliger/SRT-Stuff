using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AddressBook.Data.Common.Records
{
  [DataContract]
  public class PhoneRecord : Record
  {
    [DataMember(Order = 1, Name = "PhoneIdentifier", IsRequired = true)]
    public string PhoneIdentifier { get; set; }
    [DataMember(Order = 2, Name = "Phone", IsRequired = true)]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number is required.")]
    public string PhoneNumber { get; set; }
  }
}