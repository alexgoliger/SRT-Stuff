using AddressBook.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
  public static class Providers
  {
    public static IRepositoryFactory Data { get; set; }

    static Providers()
    {
      Data = new RepositoryFactory();
      Data.Initialize();
    }
  }
}
