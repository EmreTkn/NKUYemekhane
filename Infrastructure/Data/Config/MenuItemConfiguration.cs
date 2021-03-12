using Core.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class MenuItemConfiguration:IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.OwnsOne(i => i.MenuOrdered, io => { io.WithOwner(); });
            builder.Property(i => i.Price).HasColumnType("decimal(18,2)");
        }
    }
}
