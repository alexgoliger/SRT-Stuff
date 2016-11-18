using AddressBook.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Repository
{
  public class RepositoryFactory : IRepositoryFactory
  {
    public NameRepository Names { get; set; }
    public StateRepository States { get; set; }
    public AddressRepository Addresses { get; set; }
    public PhoneRepository Phones { get; set; }
    public EmailRepository Emails { get; set; }
    public PersonRepository People { get; set; }

    public void Initialize()
    {
      Guid callToken = Guid.NewGuid();
      AddressBookEntities context = new AddressBookEntities();
      Names = new NameRepository(callToken, context);
      States = new StateRepository(callToken, context);
      Addresses = new AddressRepository(callToken, context);
      Phones = new PhoneRepository(callToken, context);
      Emails = new EmailRepository(callToken, context);
      People = new PersonRepository(callToken, context);
    }
  }
}
