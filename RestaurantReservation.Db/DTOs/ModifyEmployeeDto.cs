namespace RestaurantReservation.Db.DTOs;

public class ModifyEmployeeDto
{
    public int? RestaurantId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Position { get; set; } = null!;
}