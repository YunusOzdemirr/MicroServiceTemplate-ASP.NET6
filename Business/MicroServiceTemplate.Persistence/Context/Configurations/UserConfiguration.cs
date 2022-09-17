using System;
using MicroServiceTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroServiceTemplate.Persistence.Context.Configurations
{
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.ToTable("Users");
        }
    }
}

