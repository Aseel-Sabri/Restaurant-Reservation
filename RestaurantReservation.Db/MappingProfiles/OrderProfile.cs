using AutoMapper;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.MappingProfiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(orderDto => orderDto.TotalAmount, opt => opt.MapFrom<TotalAmountValueResolver>());
        CreateMap<ModifyOrderDto, Order>();
    }
}

public class TotalAmountValueResolver : IValueResolver<Order, OrderDto, double>
{
    private readonly IOrderRepository _orderRepository;

    public TotalAmountValueResolver(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public double Resolve(Order source, OrderDto destination, double destMember, ResolutionContext context)
    {
        return _orderRepository.GetOrderTotalAmount(source.OrderId).Result;
    }
}