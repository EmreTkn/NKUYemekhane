using Core.Entities.Order;

namespace Core.Specification
{
    public class OrderByPaymentIntentIdSpecification : BaseSpecification<OrderAggregate>
    {
        public OrderByPaymentIntentIdSpecification(string paymentIntentId)
            : base(o => o.PaymentIntentId == paymentIntentId)
        {
        }
    }
}
