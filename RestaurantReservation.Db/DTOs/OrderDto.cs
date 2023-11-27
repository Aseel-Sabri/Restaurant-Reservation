namespace RestaurantReservation.Db.DTOs;

public class OrderDto
{
    public int OrderId { get; set; }
    public int ReservationId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }
    public double TotalAmount { get; set; }
}