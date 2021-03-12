using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Entities.Order;


namespace API.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Menu, MenuToReturnDto>()
                .ForMember(x => x.DinnerTime, y => y.MapFrom(s => s.DinnerTime.Name))
                .ForMember(x => x.SchoolName, y => y.MapFrom(s => s.SchoolName.Name));
            CreateMap<School, SchoolDto>();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<OrderAggregate, OrderToReturnDto>();
            CreateMap<MenuItem, OrderItemDto>()
                .ForMember(d => d.MenuId, o => o.MapFrom(x => x.MenuOrdered.MenuItemId))
                .ForMember(d => d.SchoolName, o => o.MapFrom(x => x.MenuOrdered.MenuName))
                .ForMember(d => d.Day, o => o.MapFrom(x => x.MenuOrdered.MenuDay))
                .ForMember(d => d.Month, o => o.MapFrom(x => x.MenuOrdered.MenuMonth))
                .ForMember(d => d.Year, o => o.MapFrom(x => x.MenuOrdered.MenuYear));

        }
    }
}
