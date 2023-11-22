namespace RestaurantReservation.Db.DTOs;

public class UpdateMenuItemDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double? Price { get; set; }
}