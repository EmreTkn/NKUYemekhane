using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AdminController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public AdminController(IUnitOfWork unitOfWork, IMapper mapper, IOrderService orderService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task UpdateMenuById(MenuUpdateSpecParams updateSpecParams)
        {
            var spec=new MenusWithDateAndIncludes(updateSpecParams.Id);
            var menu = await _unitOfWork.Repository<Menu>().GetEntityWithSpec(spec);
            if (updateSpecParams.FoodFirst != null)
            {
                menu.FoodFirst = updateSpecParams.FoodFirst;
            }

            if (updateSpecParams.FoodSecond != null)
            {
                menu.FoodSecond = updateSpecParams.FoodSecond;
            }

            if (updateSpecParams.FoodThird != null)
            {
                menu.FoodThird = updateSpecParams.FoodThird;
            }

            if (updateSpecParams.FoodFourth != null)
            {
                menu.FoodFourth = updateSpecParams.FoodFourth;
            }

           
                _unitOfWork.Repository<Menu>().Update(menu);
                await _unitOfWork.Complete();
            

            
        }
    }
}
