using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Common.Responses
{
  [DataContract]
  public class InsertNameResponse : Response
  {
    [DataMember(Name = "NameIdentifier", IsRequired = true)]
    public string NameIdentifier { get; set; }
  }
}
