using RestaurantReservation.Db.DTOs;

namespace RestaurantReservation.Db.ValueObjects;

public class OrdersAndMenuItems
{
    public int OrderId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }
    public Double TotalAmount { get; set; }
    public List<MenuItemDto> MenuItems { get; set; } = new List<MenuItemDto>();
}