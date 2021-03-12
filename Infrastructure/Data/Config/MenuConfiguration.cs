using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class MenuConfiguration:IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(m => m.Price).HasColumnType("decimal(18,2)");
            builder.HasOne(m => m.SchoolName).WithMany()
                .HasForeignKey(p => p.SchoolNameId);
            builder.HasOne(m => m.DinnerTime).WithMany()
                .HasForeignKey(k => k.DinnerTimeId);
        }
    }
}
