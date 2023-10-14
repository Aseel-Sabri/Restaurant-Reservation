namespace RestaurantReservation.Db.DTOs;

public class TableDto
{
    public int TableId { get; set; }
    public int? RestaurantId { get; set; }
    public int? Capacity { get; set; }

    public override string ToString()
    {
        return $"""
                TableId: {TableId}
                RestaurantId: {RestaurantId}
                Capacity: {Capacity}
                """;
    }
}