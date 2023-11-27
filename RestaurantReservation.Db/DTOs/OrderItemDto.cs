namespace RestaurantReservation.Db.DTOs;

public class OrderItemDto
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int MenuItemId { get; set; }
    public int Quantity { get; set; }

    public override string ToString()
    {
        return $"""
                OrderItemId: {OrderItemId}
                OrderId: {OrderId}
                MenuItemId: {MenuItemId}
                Quantity: {Quantity}
                """;
    }
}