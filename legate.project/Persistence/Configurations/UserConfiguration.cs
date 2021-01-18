using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Id).IsRequired();
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.Name).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Phone).IsRequired();
            builder.Property(e => e.salary).IsRequired();
            builder.Property(e => e.Postion).IsRequired().HasMaxLength(15);
            builder.Property(e => e.Age).IsRequired();
            builder.Property(e => e.Address).IsRequired().HasMaxLength(25);
            builder.Property(e => e.JoiningDate).IsRequired();
            

        }
    }
}
