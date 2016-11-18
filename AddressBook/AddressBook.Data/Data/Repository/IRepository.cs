using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Repository
{
  public interface IRepository<TEntity, TKey>
  {
    void Add(TEntity entity);
    TEntity Get(TKey key);
    void Update(TEntity entity);
    TEntity Find(Func<TEntity, bool> predicate);
    List<TEntity> FindAll(Func<TEntity, bool> predicate);
  }
}
