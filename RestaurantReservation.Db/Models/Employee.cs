﻿namespace RestaurantReservation.Db.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    public Restaurant Restaurant { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
}