using System;
using Core.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
   public class OrderAggregateConfiguration:IEntityTypeConfiguration<OrderAggregate>
    {
        public void Configure(EntityTypeBuilder<OrderAggregate> builder)
        {
            builder.Property(s => s.OrderStatus).HasConversion(
                o => o.ToString(),
                o => (OrderStatus) Enum.Parse(typeof(OrderStatus), o)
            );

            builder.HasMany(o => o.Menus)
                .WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
