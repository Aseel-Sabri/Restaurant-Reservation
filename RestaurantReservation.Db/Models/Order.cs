using EntityFrameworkCore.Projectables;

namespace RestaurantReservation.Db.Models;

public class Order
{
    public int OrderId { get; set; }
    public Reservation Reservation { get; set; }
    public int ReservationId { get; set; }
    public Employee Employee { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [Projectable] public Double TotalAmount => OrderItems.Sum(orderItem => orderItem.Quantity * orderItem.Item.Price);
}