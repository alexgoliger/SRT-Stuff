using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Repository
{
  public interface IRepositoryFactory
  {
    void Initialize();

    NameRepository Names { get; set; }
    StateRepository States { get; set; }
    AddressRepository Addresses { get; set; }
    PhoneRepository Phones { get; set; }
    EmailRepository Emails { get; set; }
    PersonRepository People { get; set; }
  }
}
