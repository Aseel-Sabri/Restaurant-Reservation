using AutoMapper;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.MappingProfiles;

public class ReservationProfile : Profile
{
    public ReservationProfile()
    {
        CreateMap<Reservation, ReservationDto>();
        CreateMap<ModifyReservationDto, Reservation>();
    }
}