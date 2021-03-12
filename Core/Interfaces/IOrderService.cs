using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Order;

namespace Core.Interfaces
{
    public interface IOrderService
    {
        Task<OrderAggregate> CreateOrderAsync(string buyerEmail, string basketId);
        Task<IReadOnlyList<OrderAggregate>> GetOrdersForUserAsync(string buyerEmail);
        Task<OrderAggregate> GetOrderByIdAsync(int id, string buyerEmail);
      
    }
}
