namespace RestaurantReservation.Db.DTOs;

public class ModifyRestaurantDto
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string OpeningHours { get; set; } = null!;
}