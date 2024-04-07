using Microsoft.EntityFrameworkCore;
using PopulationСensus.Domain.Entities;

namespace PopulationСensus.Data
{
    public class СensusContext : DbContext
    {
        public СensusContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
