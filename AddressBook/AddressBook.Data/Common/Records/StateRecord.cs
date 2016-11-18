using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AddressBook.Data.Common.Records
{
  [DataContract]
  public class StateRecord : Record
  {
    [DataMember(Order = 1, Name = "StateIdentifier", IsRequired = true)]
    public string StateIdentifier { get; set; }
    [DataMember(Order = 2, Name = "State", IsRequired = true)]
    [Required(AllowEmptyStrings = false, ErrorMessage = "State is required.")]
    public string State { get; set; }
  }
}