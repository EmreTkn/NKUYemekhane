using Core.Entities.Order;

namespace Core.Specification
{
    public class OrdersWithItemsAndOrderingSpecification:BaseSpecification<OrderAggregate>
    {
        public OrdersWithItemsAndOrderingSpecification(string email) : base(o => o.BuyerEmail == email)
        {
            AddInclude(o => o.Menus);
            AddOrderByDescending(o => o.OrderDate);
        }

        public OrdersWithItemsAndOrderingSpecification(int id, string email)
            : base(o => o.Id == id && o.BuyerEmail == email)
        {
            AddInclude(o => o.Menus);
        }
    }
}
