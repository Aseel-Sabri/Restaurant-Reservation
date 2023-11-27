using AutoMapper;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.MappingProfiles;

public class TableProfile : Profile
{
    public TableProfile()
    {
        CreateMap<Table, TableDto>();
        CreateMap<CreateTableDto, Table>();
        CreateMap<UpdateTableDto, Table>();
    }
}