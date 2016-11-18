using AddressBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Common.Responses
{
  [DataContract]
  public class SearchNamesResponse : Response
  {
    [DataMember(Name = "Names", IsRequired = true)]
    public List<Name> Names { get; set; }
  }
}
