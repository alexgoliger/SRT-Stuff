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
  public class UpdatePersonRequest : Request
  {
    [DataMember(Name = "PersonRecord", IsRequired = false)]
    public PersonRecord PersonRecord { get; set; }
  }
}
