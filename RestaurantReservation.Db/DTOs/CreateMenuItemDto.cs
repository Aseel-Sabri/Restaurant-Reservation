namespace RestaurantReservation.Db.DTOs;

public class CreateMenuItemDto
{
    public int? RestaurantId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double? Price { get; set; }
}