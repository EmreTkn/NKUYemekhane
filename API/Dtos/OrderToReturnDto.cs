using System;
using System.Collections.Generic;


namespace API.Dtos
{
    public class OrderToReturnDto
    {
        public int  Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public IReadOnlyList<OrderItemDto> Menus { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public string OrderStatus { get; set; }
    }
}
