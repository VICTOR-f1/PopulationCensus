﻿using Microsoft.EntityFrameworkCore;
using PopulationСensus.Domain.Entities;

namespace PopulationСensus.Data
{
    public class ELibraryContext : DbContext
    {
        public ELibraryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
