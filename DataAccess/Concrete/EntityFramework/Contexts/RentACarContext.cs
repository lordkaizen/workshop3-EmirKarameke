using Entities.Concrete;
using Entities.Persons;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts;

public class RentACarContext : DbContext
{
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Fuel> Fuels { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }
    public DbSet<Model> Models { get; set; }

    public DbSet<Users> Users { get; set; }
    public DbSet<Customers> Customers { get; set; }
    public DbSet<IndividualCustomers> IndividualCustomers { get; set; }

    public DbSet<CorporateCustomers> CorporateCustomers { get; set; }

    public RentACarContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions) { }
}
