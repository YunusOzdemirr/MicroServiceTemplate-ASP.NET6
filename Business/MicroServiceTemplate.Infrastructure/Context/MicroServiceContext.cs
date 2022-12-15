using System;
using MediatR;
using MicroServiceTemplate.Application.Interfaces.Context;
using MicroServiceTemplate.Domain.Common;
using MicroServiceTemplate.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceTemplate.Infrastructure.Context
{
    public class MicroServiceContext : DbContext, IApplicationDbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "microServiceContext";
        private readonly IMediator _mediator;

        //public DbSet<User> Users { get; set; }

        public MicroServiceContext()
        {
        }

        public MicroServiceContext(DbContextOptions<MicroServiceContext> options, IMediator mediator)
            : base(options) => _mediator = mediator;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                connectionString:
                @"Server=localhost;Database=MicroServiceContext;User=sa;Password=<YourStrong@Passw0rd>;");

            base.OnConfiguring(optionsBuilder);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);
            await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}