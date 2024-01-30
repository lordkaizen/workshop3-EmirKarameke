using DataAccess.Abstract.Person;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Persons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Person;

public class EfCustomerDal : ICustomerDal
{
    private readonly RentACarContext _context;

    public EfCustomerDal(RentACarContext context)
    {
        _context = context;
    }
    public Customers Add(Customers entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        //_context.Entry(entity).State = EntityState.Added;
        _context.Customers.Add(entity);

        _context.SaveChanges(); // Unit of Work
        return entity;
    }

    public Customers Delete(Customers entity, bool isSoftDelete = true)
    {
        entity.DeletedAt = DateTime.UtcNow;
        // _context.Entry(entity).State = EntityState.Modified;

        if (!isSoftDelete)
            _context.Customers.Remove(entity);

        _context.SaveChanges();
        return entity;
    }

    public Customers? Get(Func<Customers, bool> predicate)
    {
        Customers? customers = _context.Customers.FirstOrDefault(predicate); // örn. FirstOrDefault() metodu veritabanına sorguyu çalıştırır.
        return customers;
    }

    public IList<Customers> GetList(Func<Customers, bool>? predicate = null)
    {
        IQueryable<Customers> query = _context.Set<Customers>();
        if (predicate != null)
            query = query.Where(predicate).AsQueryable();

        return query.ToList();
    }

    public Customers Update(Customers entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
        _context.Customers.Update(entity);

        _context.SaveChanges();
        return entity;
    }
}
