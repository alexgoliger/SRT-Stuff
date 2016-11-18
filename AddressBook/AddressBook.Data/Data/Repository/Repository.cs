using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Repository
{
  /// <summary>
  /// An abstract base class that provides basic methods for database operations.
  /// </summary>
  /// <typeparam name="TContext">A type derived from the System.Data.Entity.DbContext class.</typeparam>
  /// <typeparam name="TEntity">The data type representing the types of objects to be persisted.</typeparam>
  /// <typeparam name="TKey">The data type of the primary key column for the database table represented by this repository.</typeparam>
  public abstract class Repository<TContext, TEntity, TKey> : IRepository<TEntity, TKey>
    where TContext : DbContext
    where TEntity : class, new()
  {
    protected TContext Context { get; private set; }
    protected abstract DbSet<TEntity> DbSet { get; }

    public Repository(Guid callToken, TContext entities)
    {
      // TODO: log callToken
      Context = entities;
    }

    public void Add(TEntity entity)
    {
      try
      {
        DbSet.Add(entity);
        Context.SaveChanges();
      }
      catch (Exception e)
      {
        // TODO: log error when adding entity
        throw e;
      }
    }

    public TEntity Find(Func<TEntity, bool> predicate)
    {
      try
      {
        return DbSet.Where(predicate).FirstOrDefault();
      }
      catch (Exception e)
      {
        // TODO: log error when finding entity
        throw e;
      }
    }

    public List<TEntity> FindAll(Func<TEntity, bool> predicate)
    {
      try
      {
        var invocationList = predicate.GetInvocationList();
        return DbSet.Where(predicate).ToList();
      }
      catch (Exception e)
      {
        // TODO: log error when finding entities
        throw e;
      }
    }

    public TEntity Get(TKey key)
    {
      try
      {
        return DbSet.Find(key);
      }
      catch (Exception e)
      {
        // TODO: log error when finding element by primary key
        throw e;
      }
    }

    public void Update(TEntity entity)
    {
      try
      {
        Context.SaveChanges();
      }
      catch (Exception e)
      {
        // TODO: log error when updating element
        throw e;
      }
    }

    public void Delete(Func<TEntity, bool> predicate)
    {
      try
      {
        var entity = Find(predicate);
        if (entity != null)
        {
          DbSet.Remove(entity);
          Context.SaveChanges();
        }
      }
      catch (Exception e)
      {
        // TODO: log error when deleting entity
        throw e;
      }
    }

    public void DeleteAll(Func<TEntity, bool> predicate)
    {
      try
      {
        var entities = FindAll(predicate);
        DbSet.RemoveRange(entities);
        Context.SaveChanges();
      }
      catch (Exception e)
      {
        // TODO: log error when deleting entities
        throw e;
      }
    }
  }
}
