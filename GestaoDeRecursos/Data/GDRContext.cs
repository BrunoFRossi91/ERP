using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Data
{
    public class GDRContext : DbContext
    {
        public GDRContext(DbContextOptions<GDRContext> opts)
            : base(opts) { }

        public DbSet<EntityCustomer> Customer { get; set; }
        public DbSet<EntityCompany> Company { get; set; }
        public DbSet<EntityUser> User { get; set; }
        public DbSet<EntityService> Service { get; set; }
        public DbSet<EntityPackage> Package { get; set; }
        public DbSet<EntityCustomerUser> CustomerUser { get; set; }
        public DbSet<EntityEmployee> Employee { get; set; }
        public DbSet<EntitySupplier> Supplier { get; set; }
        public DbSet<EntityProduct> Product { get; set; }
    }
}
