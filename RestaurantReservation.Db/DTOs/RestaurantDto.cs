namespace RestaurantReservation.Db.DTOs;

public class RestaurantDto
{
    public int RestaurantId { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string OpeningHours { get; set; } = null!;
}