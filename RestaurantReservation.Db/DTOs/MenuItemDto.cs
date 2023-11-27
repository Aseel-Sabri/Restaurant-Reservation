namespace RestaurantReservation.Db.DTOs;

public class MenuItemDto
{
    public int ItemId { get; set; }
    public int RestaurantId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Price { get; set; }
}