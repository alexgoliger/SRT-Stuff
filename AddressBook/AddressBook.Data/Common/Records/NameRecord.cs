using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System;
using System.Text;

namespace AddressBook.Data.Common.Records
{
  [DataContract]
  public class NameRecord : Record
  {
    [DataMember(Order = 1, Name = "NameIdentifier", IsRequired = true)]
    public string NameIdentifier { get; set; }
    [DataMember(Order = 2, Name = "FirstName", IsRequired = true)]
    [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required.")]
    public string FirstName { get; set; }
    [DataMember(Order = 3, Name = "MiddleName", IsRequired = false)]
    public string MiddleName { get; set; }
    [DataMember(Order = 4, Name = "LastName", IsRequired = true)]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required.")]
    public string LastName { get; set; }
  }
}