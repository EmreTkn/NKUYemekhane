using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Order;

namespace Core.Interfaces
{
    public interface IPaymentService
    {
        Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
        Task<OrderAggregate> UpdateOrderPaymentSucceeded(string paymentIntentId);
        Task<OrderAggregate> UpdateOrderPaymentFailed(string paymentIntentId);
    }
}
