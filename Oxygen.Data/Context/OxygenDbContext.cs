using Microsoft.EntityFrameworkCore;
using Oxygen.Domain.Entities;
using System.Reflection;

namespace Oxygen.Data.Context
{
    public class OxygenDbContext : DbContext
    {

        public OxygenDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Client> Accounts { get; set; }

    }
}
