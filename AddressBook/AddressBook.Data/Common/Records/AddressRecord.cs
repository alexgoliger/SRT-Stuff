using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System;
using System.Text;

namespace AddressBook.Data.Common.Records
{
  [DataContract]
  public class AddressRecord : Record
  {
    [DataMember(Order = 1, Name = "AddressIdentifier", IsRequired = true)]
    public string AddressIdentifier { get; set; }
    [DataMember(Order = 2, Name = "Street", IsRequired = true)]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Street is required.")]
    public string Street { get; set; }
    [DataMember(Order = 3, Name = "City", IsRequired = true)]
    [Required(AllowEmptyStrings = false, ErrorMessage = "City is required.")]
    public string City { get; set; }
    [DataMember(Order = 4, Name = "State", IsRequired = true)]
    [Required(AllowEmptyStrings = false, ErrorMessage = "State is required.")]
    public string State { get; set; }
    [DataMember(Order = 5, Name = "Zip", IsRequired = true)]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Zip is required.")]
    public string Zip { get; set; }
  }
}