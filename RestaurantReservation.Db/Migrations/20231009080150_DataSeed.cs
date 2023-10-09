using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John", "Doe", "555-1234" },
                    { 2, "alice.johnson@example.com", "Alice", "Johnson", "555-5678" },
                    { 3, "bob.smith@example.com", "Bob", "Smith", "555-8765" },
                    { 4, "emily.davis@example.com", "Emily", "Davis", "555-4321" },
                    { 5, "michael.miller@example.com", "Michael", "Miller", "555-9876" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Address", "Name", "OpeningHours", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St, Cityville", "The Gourmet Spot", "08:00 - 22:00", "555-1111" },
                    { 2, "456 Oak St, Townsville", "Pasta Paradise", "11:00 - 21:00", "555-2222" },
                    { 3, "789 Pine St, Villageland", "Sushi Haven", "12:00 - 20:00", "555-3333" },
                    { 4, "101 Elm St, Hamletville", "Burger Bistro", "10:00 - 19:00", "555-4444" },
                    { 5, "202 Maple St, Burgertown", "Mediterranean Delight", "9:00 - 18:00", "555-5555" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "Position", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "John", "Doe", "Chef", 1 },
                    { 2, "Alice", "Johnson", "Waiter", 1 },
                    { 3, "Bob", "Smith", "Manager", 1 },
                    { 4, "Emily", "Davis", "Chef", 1 },
                    { 5, "Michael", "Miller", "Waiter", 2 },
                    { 6, "Sophia", "Brown", "Waiter", 2 },
                    { 7, "Daniel", "Taylor", "Chef", 2 },
                    { 8, "Olivia", "Moore", "Manager", 2 },
                    { 9, "David", "Wilson", "Manager", 3 },
                    { 10, "Emma", "Jones", "Chef", 3 },
                    { 11, "Liam", "Johnson", "Waiter", 3 },
                    { 12, "Ava", "Smith", "Chef", 3 },
                    { 13, "Noah", "Davis", "Waiter", 4 },
                    { 14, "Isabella", "Miller", "Manager", 4 },
                    { 15, "Mason", "Wilson", "Waiter", 4 },
                    { 16, "Sophie", "Brown", "Chef", 4 },
                    { 17, "Ethan", "Taylor", "Waiter", 5 },
                    { 18, "Aria", "Moore", "Chef", 5 },
                    { 19, "Carter", "Wilson", "Waiter", 5 },
                    { 20, "Lily", "Jones", "Manager", 5 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "ItemId", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Classic Italian pasta dish with meat sauce", "Spaghetti Bolognese", 12.99m, 1 },
                    { 2, "Assortment of fresh sushi rolls", "Sushi Combo", 22.5m, 1 },
                    { 3, "Juicy beef patty with gourmet toppings", "Gourmet Burger", 15.75m, 1 },
                    { 4, "Fresh salad with tomatoes, olives, and feta cheese", "Mediterranean Salad", 9.99m, 1 },
                    { 5, "Decadent chocolate dessert with a gooey center", "Chocolate Fondant", 8.5m, 2 },
                    { 6, "Creamy Alfredo sauce with grilled chicken", "Chicken Alfredo", 14.5m, 2 },
                    { 7, "Spicy tuna, avocado, and cucumber sushi roll", "Dragon Roll", 18.75m, 2 },
                    { 8, "Beef patty with BBQ sauce, bacon, and cheddar", "BBQ Bacon Burger", 16.99m, 2 },
                    { 9, "Grilled lamb with tzatziki sauce in a pita", "Greek Gyro", 11.25m, 3 },
                    { 10, "Classic Italian coffee-flavored dessert", "Tiramisu", 7.99m, 3 },
                    { 11, "Layers of pasta, ricotta, meat sauce, and mozzarella", "Lasagna", 13.5m, 3 },
                    { 12, "Assorted fish and avocado sushi roll", "Rainbow Roll", 20.25m, 3 },
                    { 13, "Plant-based patty with fresh veggies", "Vegetarian Burger", 14.99m, 4 },
                    { 14, "Tomato, mozzarella, and basil salad", "Caprese Salad", 10.5m, 4 },
                    { 15, "Creamy New York-style cheesecake", "Cheesecake", 9.25m, 4 },
                    { 16, "Creamy Alfredo sauce with fettuccine pasta", "Fettuccine Alfredo", 12.75m, 4 },
                    { 17, "Udon noodles in a savory broth with tempura", "Tempura Udon", 15.5m, 5 },
                    { 18, "Grilled chicken with chipotle mayo and pepper jack cheese", "Chipotle Chicken Burger", 17.25m, 5 },
                    { 19, "Romaine lettuce, croutons, and parmesan with Caesar dressing", "Caesar Salad", 8.99m, 5 },
                    { 20, "Warm chocolate cake with a gooey molten center", "Molten Lava Cake", 10.99m, 5 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 5, 1 },
                    { 3, 10, 1 },
                    { 4, 2, 1 },
                    { 5, 6, 2 },
                    { 6, 10, 2 },
                    { 7, 10, 2 },
                    { 8, 2, 2 },
                    { 9, 10, 3 },
                    { 10, 10, 3 },
                    { 11, 7, 3 },
                    { 12, 5, 3 },
                    { 13, 3, 4 },
                    { 14, 2, 4 },
                    { 15, 10, 4 },
                    { 16, 9, 4 },
                    { 17, 7, 5 },
                    { 18, 8, 5 },
                    { 19, 4, 5 },
                    { 20, 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CustomerId", "PartySize", "ReservationDate", "RestaurantId", "TableId" },
                values: new object[,]
                {
                    { 1, 1, 4, new DateTime(2023, 10, 10, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5249), 1, 1 },
                    { 2, 1, 2, new DateTime(2023, 10, 11, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5304), 1, 2 },
                    { 3, 3, 6, new DateTime(2023, 10, 12, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5308), 2, 5 },
                    { 4, 4, 8, new DateTime(2023, 10, 13, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5311), 2, 6 },
                    { 5, 5, 3, new DateTime(2023, 10, 14, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5315), 3, 9 },
                    { 6, 5, 3, new DateTime(2023, 10, 14, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5320), 4, 15 },
                    { 7, 5, 3, new DateTime(2023, 10, 14, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5323), 5, 19 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "EmployeeId", "OrderDate", "ReservationId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 8, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5424), 1, 99.99m },
                    { 2, 1, new DateTime(2023, 10, 7, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5449), 2, 81.69m },
                    { 3, 1, new DateTime(2023, 10, 6, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5460), 3, 217.96m },
                    { 4, 1, new DateTime(2023, 10, 5, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5484), 4, 174.75m },
                    { 5, 1, new DateTime(2023, 10, 4, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5502), 5, 98.22m },
                    { 6, 1, new DateTime(2023, 10, 3, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5512), 6, 49.75m },
                    { 7, 1, new DateTime(2023, 10, 2, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5521), 7, 64.48m }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "MenuItemId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 2, 1, 4 },
                    { 2, 4, 1, 1 },
                    { 3, 1, 2, 2 },
                    { 4, 4, 2, 2 },
                    { 5, 4, 2, 2 },
                    { 6, 3, 2, 1 },
                    { 7, 8, 3, 4 },
                    { 8, 7, 3, 4 },
                    { 9, 7, 3, 4 },
                    { 10, 7, 4, 1 },
                    { 11, 6, 4, 3 },
                    { 12, 7, 4, 2 },
                    { 13, 7, 4, 4 },
                    { 14, 10, 5, 3 },
                    { 15, 12, 5, 1 },
                    { 16, 11, 5, 4 },
                    { 17, 16, 6, 1 },
                    { 18, 15, 6, 4 },
                    { 19, 17, 7, 2 },
                    { 20, 17, 7, 1 },
                    { 21, 19, 7, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 5);
        }
    }
}
