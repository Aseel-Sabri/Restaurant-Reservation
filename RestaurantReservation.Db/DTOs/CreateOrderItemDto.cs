﻿namespace RestaurantReservation.Db.DTOs;

public class CreateOrderItemDto
{
    public int? MenuItemId { get; set; }
    public int? Quantity { get; set; }
}