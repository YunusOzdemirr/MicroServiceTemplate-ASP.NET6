using System;
using MicroServiceTemplate.Application.Interfaces.Context;
using MicroServiceTemplate.Domain.Entities;
using MicroServiceTemplate.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceTemplate.Persistence.Context
{
    public class MicroServiceContext:DbContext,IApplicationDbContext
    {
        public MicroServiceContext()
        {
        }
        public MicroServiceContext(DbContextOptions<MicroServiceContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=localhost;Database=MicroServiceContext;User=sa;Password=<YourStrong@Passw0rd>;");

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
    }
}

