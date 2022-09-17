using System;

namespace MicroServiceTemplate.Application.Interfaces.Context
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
    }
}

