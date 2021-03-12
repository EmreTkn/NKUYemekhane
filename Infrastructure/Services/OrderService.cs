using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Order;
using Core.Interfaces;
using Core.Specification;

namespace Infrastructure.Services
{
   public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;
        public OrderService(IBasketRepository basketRepo, IUnitOfWork unitOfWork, IPaymentService paymentService)
        {
            _paymentService = paymentService;
            _unitOfWork = unitOfWork;
            _basketRepo = basketRepo;
        }

        public async Task<OrderAggregate> CreateOrderAsync(string buyerEmail, string basketId)
        {
            // get basket from the repo
            var basket = await _basketRepo.GetBasketAsync(basketId);

            // get items from the product repo
            var items = new List<MenuItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _unitOfWork.Repository<Menu>().GetByIdAsync(item.Id);
                
                var itemOrdered = new MenuItemOrdered(productItem.Id,productItem.FoodFirst,productItem.Day,productItem.Month,productItem.Year,item.SchoolName,item.DinnerTime);
                var orderItem = new MenuItem(itemOrdered, productItem.Price);
                items.Add(orderItem);
            }


            // calc subtotal
            var subtotal = items.Sum(item => item.Price);

            // check to see if order exists
            var spec = new OrderByPaymentIntentIdSpecification(basket.PaymentIntentId);
            var existingOrder = await _unitOfWork.Repository<OrderAggregate>().GetEntityWithSpec(spec);

            if (existingOrder != null)
            {
                _unitOfWork.Repository<OrderAggregate>().Delete(existingOrder);
                await _paymentService.CreateOrUpdatePaymentIntent(basket.PaymentIntentId);
            }

            // create order
            var order = new OrderAggregate(items,subtotal,buyerEmail,basket.PaymentIntentId);
            _unitOfWork.Repository<OrderAggregate>().Add(order);

            // save to db
            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;

            // return order
            return order;
        }


        public async Task<OrderAggregate> GetOrderByIdAsync(int id, string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(id, buyerEmail);

            return await _unitOfWork.Repository<OrderAggregate>().GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<OrderAggregate>> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(buyerEmail);
            var data = await _unitOfWork.Repository<OrderAggregate>().ListAsync(spec);
            return data;
        }
    }
}
