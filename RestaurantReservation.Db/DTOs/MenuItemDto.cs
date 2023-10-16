namespace RestaurantReservation.Db.DTOs;

public class MenuItemDto
{
    public int ItemId;
    public int? RestaurantId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double? Price { get; set; }

    public override string ToString()
    {
        return $"""
                ItemId: {ItemId}
                RestaurantId: {RestaurantId}
                Name: {Name}
                Description: {Description}
                Price: {Price}
                """;
    }
}