namespace RestaurantReservation.Db.KeylessEntities;

public class ReservationDetails
{
    public int ReservationId { get; set; }
    public int TableId { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerPhoneNumber { get; set; }
    public int RestaurantId { get; set; }
    public string RestaurantName { get; set; }
    public string RestaurantAddress { get; set; }
    public string OpeningHours { get; set; }
    public string RestaurantPhoneNumber { get; set; }

    public override string ToString()
    {
        return $"""
                {nameof(ReservationId)}: {ReservationId}
                {nameof(TableId)}: {TableId}
                {nameof(CustomerId)}: {CustomerId}
                {nameof(CustomerName)}: {CustomerName}
                {nameof(CustomerEmail)}: {CustomerEmail}
                {nameof(CustomerPhoneNumber)}: {CustomerPhoneNumber} 
                {nameof(RestaurantId)}: {RestaurantId}
                {nameof(RestaurantName)}: {RestaurantName}
                {nameof(RestaurantAddress)}: {RestaurantAddress}
                {nameof(OpeningHours)}: {OpeningHours}
                {nameof(RestaurantPhoneNumber)}: {RestaurantPhoneNumber}
                """;
    }
}