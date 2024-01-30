using DataAccess.Abstract.Person;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Persons;

namespace DataAccess.Concrete.EntityFramework.Person
{
    public class EfUserDal : IUserDal
    {
        private readonly RentACarContext _context;

        public EfUserDal(RentACarContext context)
        {
            _context = context;
        }
        public Users Add(Users entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            //_context.Entry(entity).State = EntityState.Added;
            _context.Users.Add(entity);

            _context.SaveChanges(); // Unit of Work
            return entity;
        }

        public Users Delete(Users entity, bool isSoftDelete = true)
        {
            entity.DeletedAt = DateTime.UtcNow;
            // _context.Entry(entity).State = EntityState.Modified;

            if (!isSoftDelete)
                _context.Users.Remove(entity);

            _context.SaveChanges();
            return entity;
        }

        public Users? Get(Func<Users, bool> predicate)
        {
            Users? customers = _context.Users.FirstOrDefault(predicate); // örn. FirstOrDefault() metodu veritabanına sorguyu çalıştırır.
            return customers;
        }

        public IList<Users> GetList(Func<Users, bool>? predicate = null)
        {
            IQueryable<Users> query = _context.Set<Users>();
            if (predicate != null)
                query = query.Where(predicate).AsQueryable();

            return query.ToList();
        }

        public Users Update(Users entity)
        {
            entity.UpdateAt = DateTime.UtcNow;
            _context.Users.Update(entity);

            _context.SaveChanges();
            return entity;
        }
    }
}
