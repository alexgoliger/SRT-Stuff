using AddressBook.Data.Common.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Common.Requests
{
  [DataContract]
  public class UpdateNameRequest : Request
  {
    [DataMember(Name = "NameRecord", IsRequired = false)]
    public NameRecord NameRecord { get; set; }
  }
}
