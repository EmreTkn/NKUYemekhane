using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MenuController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly StoreContext _context;


        public MenuController(IUnitOfWork unitOfWork, IMapper mapper, StoreContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }
        [HttpGet("getmenu")]
        public async Task<Menu> GetMenuByDateAsync(int id)
        {
            var spec = new MenusWithDateAndIncludes(id);
            return await _unitOfWork.Repository<Menu>().GetEntityWithSpec(spec);
        }


        [HttpGet("getall")]
        public async Task<IReadOnlyList<MenuToReturnDto>> GetAllMenu([FromQuery]MenuSpecParams menuParams)
        {
            var spec = new MenusWithDateAndIncludes(menuParams);     
            var menus = await _unitOfWork.Repository<Menu>().ListAsync(spec);

            if (!menus.Any())
            {
            await StoreContextSeed.CalculateDaysAsync(_context, menuParams.Month, menuParams.Year,menuParams.DinnerTimeId,menuParams.SchoolNameId);
            menus= await _unitOfWork.Repository<Menu>().ListAsync(spec);
            }

            var data = _mapper.Map<IReadOnlyList<Menu>, IReadOnlyList<MenuToReturnDto>>(menus);
            return data;
        }

        [HttpGet("schoolName")]
        public async Task<IReadOnlyList<SchoolName>> GetSchoolNames()
        {
            var school = await _unitOfWork.Repository<SchoolName>().ListAllAsync();
            return school;
        }
    }
}
