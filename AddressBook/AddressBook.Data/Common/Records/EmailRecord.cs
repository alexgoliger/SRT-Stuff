using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AddressBook.Data.Common.Records
{
  [DataContract]
  public class EmailRecord : Record
  {
    [DataMember(Order = 1, Name = "EmailIdentifier", IsRequired = true)]
    public string EmailIdentifier { get; set; }
    [DataMember(Order = 2, Name = "Email", IsRequired = true)]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
    public string Email { get; set; }
  }
}