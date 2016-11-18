using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Common.Responses
{
  [DataContract]
  public class Status
  {
    [DataMember(Order = 1, Name = "IsSuccessful", IsRequired = true)]
    public bool IsSuccessful { get; set; }
    [DataMember(Order = 2, Name = "ErrorMessage", IsRequired = false)]
    public string ErrorMessage { get; set; }
  }
}
