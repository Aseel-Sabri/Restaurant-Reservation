namespace RestaurantReservation.Db.DTOs;

public class ReservationDto
{
    public int ReservationId { get; set; }
    public int? CustomerId { get; set; }
    public int? RestaurantId { get; set; }
    public int? TableId { get; set; }
    public DateTime? ReservationDate { get; set; }
    public int? PartySize { get; set; }

    public override string ToString()
    {
        return $"""
                ReservationId: {ReservationId}
                CustomerId: {CustomerId}
                RestaurantId: {RestaurantId}
                TableId: {TableId}
                ReservationDate: {ReservationDate}
                PartySize: {PartySize}
                """;
    }
}