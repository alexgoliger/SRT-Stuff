using AddressBook.Data.ServiceCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Common.Responses
{
  public interface IResponse
  {
    Status Status { get; set; }
  }
}
