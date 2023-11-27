namespace RestaurantReservation.Db.Models;

public class MenuItem
{
    public int ItemId;
    public Restaurant Restaurant { get; set; }
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}