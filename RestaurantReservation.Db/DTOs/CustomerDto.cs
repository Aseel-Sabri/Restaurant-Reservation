namespace RestaurantReservation.Db.DTOs;

public class CustomerDto
{
    public int CustomerId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public override string ToString()
    {
        return $"""
                CustomerId: {CustomerId}
                FirstName: {FirstName}
                LastName: {LastName}
                Email: {Email}
                PhoneNumber: {PhoneNumber}
                """;
    }
}