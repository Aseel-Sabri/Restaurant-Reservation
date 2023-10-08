﻿namespace RestaurantReservation.Db.Models;

public class Order
{
    public int OrderId { get; set; }
    public Reservation Reservation { get; set; }
    public int ReservationId { get; set; }
    public Employee Employee { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }
    public Double TotalAmount { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}