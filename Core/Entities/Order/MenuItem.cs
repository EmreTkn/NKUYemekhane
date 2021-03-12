

namespace Core.Entities.Order
{
    public class MenuItem:BaseEntity
    {
        public MenuItem()
        {
            
        }

        public MenuItem(MenuItemOrdered menuOrdered, decimal price)
        {
            MenuOrdered = menuOrdered;
            Price = price;
        }
        public MenuItemOrdered MenuOrdered { get; set; }
        public decimal Price { get; set; }
    }
}
