using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Identifiers
{
  public interface Identifier
  {
    int PersistableID { get; }
    string DisplayableIdentifier { get; }
  }
}
