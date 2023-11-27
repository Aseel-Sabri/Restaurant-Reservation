namespace RestaurantReservation.Db.DTOs;

public class OrdersAndMenuItemsDto
{
    public int OrderId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }
    public Double TotalAmount { get; set; }
    public List<MenuItemDto> MenuItems { get; set; } = new List<MenuItemDto>();
}