using AutoMapper;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.MappingProfiles;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<Restaurant, RestaurantDto>();
        CreateMap<ModifyRestaurantDto, Restaurant>();
    }
}