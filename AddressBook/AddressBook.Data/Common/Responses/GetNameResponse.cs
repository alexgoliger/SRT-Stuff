﻿using AddressBook.Data.Common.Records;
using System.Runtime.Serialization;

namespace AddressBook.Data.Common.Responses
{
  [DataContract]
  public class GetNameResponse : Response
  {
    [DataMember(Name = "Name", IsRequired = true)]
    public NameRecord Name;
  }
}