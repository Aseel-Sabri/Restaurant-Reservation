namespace RestaurantReservation.Db.DTOs;

public class EmployeeDto
{
    public int EmployeeId { get; set; }
    public int RestaurantId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Position { get; set; } = null!;
}