using System;
using System.Collections.Generic;

namespace Core.Entities.Order
{
    public class OrderAggregate:BaseEntity
    {
        public OrderAggregate()
        {
            
        }

        public OrderAggregate(IReadOnlyList<MenuItem> menus, decimal subtotal, string buyerEmail, string paymentIntentId)
        {
            Menus = menus;
            Subtotal = subtotal;
            BuyerEmail = buyerEmail;
            PaymentIntentId = paymentIntentId;
        }
        public IReadOnlyList<MenuItem> Menus { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public decimal Subtotal { get; set; }
        public string BuyerEmail { get; set; }
        public string PaymentIntentId { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;

    }
}
