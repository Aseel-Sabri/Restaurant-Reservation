namespace RestaurantReservation.Db.ValueObjects;

public class EmployeeDetails
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public string Position { get; set; }
    public int RestaurantId { get; set; }
    public string RestaurantName { get; set; }
    public string RestaurantAddress { get; set; }
    public string RestaurantPhoneNumber { get; set; }
    public string OpeningHours { get; set; }

    public override string ToString()
    {
        return $"""
                {nameof(EmployeeId)}: {EmployeeId}
                {nameof(EmployeeName)}: {EmployeeName}
                {nameof(Position)}: {Position}
                {nameof(RestaurantId)}: {RestaurantId}
                {nameof(RestaurantName)}: {RestaurantName}
                {nameof(RestaurantAddress)}: {RestaurantAddress}
                {nameof(RestaurantPhoneNumber)}: {RestaurantPhoneNumber}
                {nameof(OpeningHours)}: {OpeningHours}
                """;
    }
}