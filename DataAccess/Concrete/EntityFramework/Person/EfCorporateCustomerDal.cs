using DataAccess.Abstract.Person;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Person;

public class EfCorporateCustomerDal : ICorporateCustomerDal
{
    private readonly RentACarContext _context;

    public EfCorporateCustomerDal(RentACarContext context)
    {
        _context = context;
    }

    public CorporateCustomers Add(CorporateCustomers entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        //_context.Entry(entity).State = EntityState.Added;
        _context.CorporateCustomers.Add(entity);

        _context.SaveChanges(); // Unit of Work
        return entity;
    }

    public CorporateCustomers Delete(CorporateCustomers entity, bool isSoftDelete = true)
    {
        entity.DeletedAt = DateTime.UtcNow;
        // _context.Entry(entity).State = EntityState.Modified;

        if (!isSoftDelete)
            _context.CorporateCustomers.Remove(entity);

        _context.SaveChanges();
        return entity;
    }

    public CorporateCustomers? Get(Func<CorporateCustomers, bool> predicate)
    {
        CorporateCustomers? model = _context.CorporateCustomers.FirstOrDefault(predicate); // örn. FirstOrDefault() metodu veritabanına sorguyu çalıştırır.
        return model;
    }

    public IList<CorporateCustomers> GetList(Func<CorporateCustomers, bool>? predicate = null)
    {
        IQueryable<CorporateCustomers> query = _context.Set<CorporateCustomers>();
        if (predicate != null)
            query = query.Where(predicate).AsQueryable();

        return query.ToList();
    }

    public CorporateCustomers Update(CorporateCustomers entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
        _context.CorporateCustomers.Update(entity);

        _context.SaveChanges();
        return entity;
    }
}
