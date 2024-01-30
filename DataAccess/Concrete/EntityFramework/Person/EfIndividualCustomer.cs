using DataAccess.Abstract.Person;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Person
{
    public class EfIndividualCustomer : IIndividualCustomerDal
    {
        private readonly RentACarContext _context;

        public EfIndividualCustomer(RentACarContext context)
        {
            _context = context;
        }
        public IndividualCustomers Add(IndividualCustomers entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            //_context.Entry(entity).State = EntityState.Added;
            _context.IndividualCustomers.Add(entity);

            _context.SaveChanges(); // Unit of Work
            return entity;
        }

        public IndividualCustomers Delete(IndividualCustomers entity, bool isSoftDelete = true)
        {
            entity.DeletedAt = DateTime.UtcNow;
            // _context.Entry(entity).State = EntityState.Modified;

            if (!isSoftDelete)
                _context.IndividualCustomers.Remove(entity);

            _context.SaveChanges();
            return entity;
        }

        public IndividualCustomers? Get(Func<IndividualCustomers, bool> predicate)
        {
            IndividualCustomers? ındividualCustomers = _context.IndividualCustomers.FirstOrDefault(predicate); // örn. FirstOrDefault() metodu veritabanına sorguyu çalıştırır.
            return ındividualCustomers;
        }

        public IList<IndividualCustomers> GetList(Func<IndividualCustomers, bool>? predicate = null)
        {
            IQueryable<IndividualCustomers> query = _context.Set<IndividualCustomers>();
            if (predicate != null)
                query = query.Where(predicate).AsQueryable();

            return query.ToList();
        }

        public IndividualCustomers Update(IndividualCustomers entity)
        {
            entity.UpdateAt = DateTime.UtcNow;
            _context.IndividualCustomers.Update(entity);

            _context.SaveChanges();
            return entity;
        }
    }
}
