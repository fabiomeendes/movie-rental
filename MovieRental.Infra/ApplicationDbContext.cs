using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Lease> Leases { get; set; }

        //public IDbConnection Connection => Database.GetDbConnection();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //foreach (var property in builder.Model.GetEntityTypes()
            //.SelectMany(t => t.GetProperties())
            //.Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            //{
            //    property.SetColumnType("decimal(18,2)");
            //}
            base.OnModelCreating(builder);
        }
    }
}