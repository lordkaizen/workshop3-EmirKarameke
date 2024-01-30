using Core.DataAccess;
using Core.Entities;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccess.Concrete.EntityFramework
{
    //public class EntityRepositoryBase<TEntity, TEntityId> : IEntityRepository<TEntity, TEntityId>
    //    where TEntity : class, IEntity<TEntityId>, new()
    //{
    //    private readonly RentACarContext _context;
    //    public EntityRepositoryBase(RentACarContext context)
    //    {
    //        _context = context;
    //    }
    //    public TEntity Add(TEntity entity)
    //    {
    //        entity.CreatedAt = DateTime.UtcNow;
    //        //_context.Entry(entity).State = EntityState.Added;
    //        _context.Set<TEntity>().Add(entity);

    //        _context.SaveChanges(); // Unit of Work
    //        return entity;
    //    }

    //    public TEntity Delete(TEntity entity, bool isSoftDelete = true)
    //    {
    //        entity.DeletedAt = DateTime.UtcNow;
    //        // _context.Entry(entity).State = EntityState.Modified;

    //        if (!isSoftDelete)
    //            _context.Set<TEntity>().Remove(entity);

    //        _context.SaveChanges();
    //        return entity;
    //    }

    //    public TEntity? Get(Func<TEntity, bool> predicate)
    //    {
    //        TEntity? entity = _context.Set<TEntity>().FirstOrDefault(predicate); // örn. FirstOrDefault() metodu veritabanına sorguyu çalıştırır.
    //        return entity;
    //    }

    //    public IList<TEntity> GetList(Func<TEntity, bool>? predicate = null)
    //    {
    //        if (predicate != null)
    //            query = query.Where(predicate).AsQueryable();

    //        return query.ToList();
    //    }

    //    public TEntity Update(TEntity entity)
    //    {
    //        entity.UpdateAt = DateTime.UtcNow;
    //        _context.Set<TEntity>().Update(entity);

    //        _context.SaveChanges();
    //        return entity;
    //    }
    //}
}
