using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.DbContext;

public static class DataSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        SeedCustomersTable(modelBuilder);
        SeedRestaurantsTable(modelBuilder);
        SeedTablesTable(modelBuilder);
        SeedEmployeesTable(modelBuilder);
        SeedReservationsTable(modelBuilder);
        SeedMenuItemsTable(modelBuilder);
        SeedOrdersTable(modelBuilder);
        SeedOrderItemsTable(modelBuilder);
    }

    private static void SeedCustomersTable(ModelBuilder modelBuilder)
    {
        var customers = new List<Customer>
        {
            new Customer
            {
                CustomerId = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "555-1234"
            },
            new Customer
            {
                CustomerId = 2,
                FirstName = "Alice",
                LastName = "Johnson",
                Email = "alice.johnson@example.com",
                PhoneNumber = "555-5678"
            },
            new Customer
            {
                CustomerId = 3,
                FirstName = "Bob",
                LastName = "Smith",
                Email = "bob.smith@example.com",
                PhoneNumber = "555-8765"
            },
            new Customer
            {
                CustomerId = 4,
                FirstName = "Emily",
                LastName = "Davis",
                Email = "emily.davis@example.com",
                PhoneNumber = "555-4321"
            },
            new Customer
            {
                CustomerId = 5,
                FirstName = "Michael",
                LastName = "Miller",
                Email = "michael.miller@example.com",
                PhoneNumber = "555-9876"
            }
        };
        modelBuilder.Entity<Customer>().HasData(customers);
    }

    private static void SeedRestaurantsTable(ModelBuilder modelBuilder)
    {
        var restaurants = new List<Restaurant>
        {
            new Restaurant
            {
                RestaurantId = 1,
                Name = "The Gourmet Spot",
                Address = "123 Main St, Cityville",
                PhoneNumber = "555-1111",
                OpeningHours = "08:00 - 22:00"
            },
            new Restaurant
            {
                RestaurantId = 2,
                Name = "Pasta Paradise",
                Address = "456 Oak St, Townsville",
                PhoneNumber = "555-2222",
                OpeningHours = "11:00 - 21:00"
            },
            new Restaurant
            {
                RestaurantId = 3,
                Name = "Sushi Haven",
                Address = "789 Pine St, Villageland",
                PhoneNumber = "555-3333",
                OpeningHours = "12:00 - 20:00"
            },
            new Restaurant
            {
                RestaurantId = 4,
                Name = "Burger Bistro",
                Address = "101 Elm St, Hamletville",
                PhoneNumber = "555-4444",
                OpeningHours = "10:00 - 19:00"
            },
            new Restaurant
            {
                RestaurantId = 5,
                Name = "Mediterranean Delight",
                Address = "202 Maple St, Burgertown",
                PhoneNumber = "555-5555",
                OpeningHours = "9:00 - 18:00"
            }
        };
        modelBuilder.Entity<Restaurant>().HasData(restaurants);
    }

    private static void SeedTablesTable(ModelBuilder modelBuilder)
    {
        var tables = new List<Table>()
        {
            new Table()
            {
                TableId = 1,
                Capacity = 2,
                RestaurantId = 1
            },
            new Table()
            {
                TableId = 2,
                Capacity = 5,
                RestaurantId = 1
            },
            new Table()
            {
                TableId = 3,
                Capacity = 10,
                RestaurantId = 1
            },
            new Table()
            {
                TableId = 4,
                Capacity = 2,
                RestaurantId = 1
            },
            new Table()
            {
                TableId = 5,
                Capacity = 6,
                RestaurantId = 2
            },
            new Table()
            {
                TableId = 6,
                Capacity = 10,
                RestaurantId = 2
            },
            new Table()
            {
                TableId = 7,
                Capacity = 10,
                RestaurantId = 2
            },
            new Table()
            {
                TableId = 8,
                Capacity = 2,
                RestaurantId = 2
            },
            new Table()
            {
                TableId = 9,
                Capacity = 10,
                RestaurantId = 3
            },
            new Table()
            {
                TableId = 10,
                Capacity = 10,
                RestaurantId = 3
            },
            new Table()
            {
                TableId = 11,
                Capacity = 7,
                RestaurantId = 3
            },
            new Table()
            {
                TableId = 12,
                Capacity = 5,
                RestaurantId = 3
            },
            new Table()
            {
                TableId = 13,
                Capacity = 3,
                RestaurantId = 4
            },
            new Table()
            {
                TableId = 14,
                Capacity = 2,
                RestaurantId = 4
            },
            new Table()
            {
                TableId = 15,
                Capacity = 10,
                RestaurantId = 4
            },
            new Table()
            {
                TableId = 16,
                Capacity = 9,
                RestaurantId = 4
            },
            new Table()
            {
                TableId = 17,
                Capacity = 7,
                RestaurantId = 5
            },
            new Table()
            {
                TableId = 18,
                Capacity = 8,
                RestaurantId = 5
            },
            new Table()
            {
                TableId = 19,
                Capacity = 4,
                RestaurantId = 5
            },
            new Table()
            {
                TableId = 20,
                Capacity = 3,
                RestaurantId = 5
            }
        };

        modelBuilder.Entity<Table>().HasData(tables);
    }

    private static void SeedEmployeesTable(ModelBuilder modelBuilder)
    {
        var employees = new List<Employee>
        {
            new Employee { EmployeeId = 1, RestaurantId = 1, FirstName = "John", LastName = "Doe", Position = "Chef" },
            new Employee
                { EmployeeId = 2, RestaurantId = 1, FirstName = "Alice", LastName = "Johnson", Position = "Waiter" },
            new Employee
                { EmployeeId = 3, RestaurantId = 1, FirstName = "Bob", LastName = "Smith", Position = "Manager" },
            new Employee
                { EmployeeId = 4, RestaurantId = 1, FirstName = "Emily", LastName = "Davis", Position = "Chef" },
            new Employee
                { EmployeeId = 5, RestaurantId = 2, FirstName = "Michael", LastName = "Miller", Position = "Waiter" },
            new Employee
                { EmployeeId = 6, RestaurantId = 2, FirstName = "Sophia", LastName = "Brown", Position = "Waiter" },
            new Employee
                { EmployeeId = 7, RestaurantId = 2, FirstName = "Daniel", LastName = "Taylor", Position = "Chef" },
            new Employee
                { EmployeeId = 8, RestaurantId = 2, FirstName = "Olivia", LastName = "Moore", Position = "Manager" },
            new Employee
                { EmployeeId = 9, RestaurantId = 3, FirstName = "David", LastName = "Wilson", Position = "Manager" },
            new Employee
                { EmployeeId = 10, RestaurantId = 3, FirstName = "Emma", LastName = "Jones", Position = "Chef" },
            new Employee
                { EmployeeId = 11, RestaurantId = 3, FirstName = "Liam", LastName = "Johnson", Position = "Waiter" },
            new Employee
                { EmployeeId = 12, RestaurantId = 3, FirstName = "Ava", LastName = "Smith", Position = "Chef" },
            new Employee
                { EmployeeId = 13, RestaurantId = 4, FirstName = "Noah", LastName = "Davis", Position = "Waiter" },
            new Employee
            {
                EmployeeId = 14, RestaurantId = 4, FirstName = "Isabella", LastName = "Miller", Position = "Manager"
            },
            new Employee
                { EmployeeId = 15, RestaurantId = 4, FirstName = "Mason", LastName = "Wilson", Position = "Waiter" },
            new Employee
                { EmployeeId = 16, RestaurantId = 4, FirstName = "Sophie", LastName = "Brown", Position = "Chef" },
            new Employee
                { EmployeeId = 17, RestaurantId = 5, FirstName = "Ethan", LastName = "Taylor", Position = "Waiter" },
            new Employee
                { EmployeeId = 18, RestaurantId = 5, FirstName = "Aria", LastName = "Moore", Position = "Chef" },
            new Employee
                { EmployeeId = 19, RestaurantId = 5, FirstName = "Carter", LastName = "Wilson", Position = "Waiter" },
            new Employee
                { EmployeeId = 20, RestaurantId = 5, FirstName = "Lily", LastName = "Jones", Position = "Manager" }
        };
        modelBuilder.Entity<Employee>().HasData(employees);
    }

    private static void SeedMenuItemsTable(ModelBuilder modelBuilder)
    {
        var menuItems = new List<MenuItem>
        {
            new MenuItem
            {
                ItemId = 1,
                RestaurantId = 1,
                Name = "Spaghetti Bolognese",
                Description = "Classic Italian pasta dish with meat sauce",
                Price = 12.99
            },
            new MenuItem
            {
                ItemId = 2,
                RestaurantId = 1,
                Name = "Sushi Combo",
                Description = "Assortment of fresh sushi rolls",
                Price = 22.50
            },
            new MenuItem
            {
                ItemId = 3,
                RestaurantId = 1,
                Name = "Gourmet Burger",
                Description = "Juicy beef patty with gourmet toppings",
                Price = 15.75
            },
            new MenuItem
            {
                ItemId = 4,
                RestaurantId = 1,
                Name = "Mediterranean Salad",
                Description = "Fresh salad with tomatoes, olives, and feta cheese",
                Price = 9.99
            },
            new MenuItem
            {
                ItemId = 5,
                RestaurantId = 2,
                Name = "Chocolate Fondant",
                Description = "Decadent chocolate dessert with a gooey center",
                Price = 8.50
            },
            new MenuItem
            {
                ItemId = 6,
                RestaurantId = 2,
                Name = "Chicken Alfredo",
                Description = "Creamy Alfredo sauce with grilled chicken",
                Price = 14.50
            },
            new MenuItem
            {
                ItemId = 7,
                RestaurantId = 2,
                Name = "Dragon Roll",
                Description = "Spicy tuna, avocado, and cucumber sushi roll",
                Price = 18.75
            },
            new MenuItem
            {
                ItemId = 8,
                RestaurantId = 2,
                Name = "BBQ Bacon Burger",
                Description = "Beef patty with BBQ sauce, bacon, and cheddar",
                Price = 16.99
            },
            new MenuItem
            {
                ItemId = 9,
                RestaurantId = 3,
                Name = "Greek Gyro",
                Description = "Grilled lamb with tzatziki sauce in a pita",
                Price = 11.25
            },
            new MenuItem
            {
                ItemId = 10,
                RestaurantId = 3,
                Name = "Tiramisu",
                Description = "Classic Italian coffee-flavored dessert",
                Price = 7.99
            },
            new MenuItem
            {
                ItemId = 11,
                RestaurantId = 3,
                Name = "Lasagna",
                Description = "Layers of pasta, ricotta, meat sauce, and mozzarella",
                Price = 13.50
            },
            new MenuItem
            {
                ItemId = 12,
                RestaurantId = 3,
                Name = "Rainbow Roll",
                Description = "Assorted fish and avocado sushi roll",
                Price = 20.25
            },
            new MenuItem
            {
                ItemId = 13,
                RestaurantId = 4,
                Name = "Vegetarian Burger",
                Description = "Plant-based patty with fresh veggies",
                Price = 14.99
            },
            new MenuItem
            {
                ItemId = 14,
                RestaurantId = 4,
                Name = "Caprese Salad",
                Description = "Tomato, mozzarella, and basil salad",
                Price = 10.50
            },
            new MenuItem
            {
                ItemId = 15,
                RestaurantId = 4,
                Name = "Cheesecake",
                Description = "Creamy New York-style cheesecake",
                Price = 9.25
            },
            new MenuItem
            {
                ItemId = 16,
                RestaurantId = 4,
                Name = "Fettuccine Alfredo",
                Description = "Creamy Alfredo sauce with fettuccine pasta",
                Price = 12.75
            },
            new MenuItem
            {
                ItemId = 17,
                RestaurantId = 5,
                Name = "Tempura Udon",
                Description = "Udon noodles in a savory broth with tempura",
                Price = 15.50
            },
            new MenuItem
            {
                ItemId = 18,
                RestaurantId = 5,
                Name = "Chipotle Chicken Burger",
                Description = "Grilled chicken with chipotle mayo and pepper jack cheese",
                Price = 17.25
            },
            new MenuItem
            {
                ItemId = 19,
                RestaurantId = 5,
                Name = "Caesar Salad",
                Description = "Romaine lettuce, croutons, and parmesan with Caesar dressing",
                Price = 8.99
            },
            new MenuItem
            {
                ItemId = 20,
                RestaurantId = 5,
                Name = "Molten Lava Cake",
                Description = "Warm chocolate cake with a gooey molten center",
                Price = 10.99
            }
        };

        modelBuilder.Entity<MenuItem>().HasData(menuItems);
    }

    private static void SeedReservationsTable(ModelBuilder modelBuilder)
    {
        var reservations = new List<Reservation>
        {
            new Reservation()
            {
                ReservationId = 1,
                CustomerId = 1,
                PartySize = 4,
                ReservationDate = new DateTime(2023, 10, 10, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5249),
                RestaurantId = 1,
                TableId = 1
            },
            new Reservation()
            {
                ReservationId = 2,
                CustomerId = 1,
                PartySize = 2,
                ReservationDate = new DateTime(2023, 10, 11, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5304),
                RestaurantId = 1,
                TableId = 2
            },
            new Reservation()
            {
                ReservationId = 3,
                CustomerId = 3,
                PartySize = 6,
                ReservationDate = new DateTime(2023, 10, 12, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5308),
                RestaurantId = 2,
                TableId = 5
            },
            new Reservation()
            {
                ReservationId = 4,
                CustomerId = 4,
                PartySize = 8,
                ReservationDate = new DateTime(2023, 10, 13, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5311),
                RestaurantId = 2,
                TableId = 6
            },
            new Reservation()
            {
                ReservationId = 5,
                CustomerId = 5,
                PartySize = 3,
                ReservationDate = new DateTime(2023, 10, 14, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5315),
                RestaurantId = 3,
                TableId = 9
            },
            new Reservation()
            {
                ReservationId = 6,
                CustomerId = 5,
                PartySize = 3,
                ReservationDate = new DateTime(2023, 10, 14, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5320),
                RestaurantId = 4,
                TableId = 15
            },
            new Reservation()
            {
                ReservationId = 7,
                CustomerId = 5,
                PartySize = 3,
                ReservationDate = new DateTime(2023, 10, 14, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5323),
                RestaurantId = 5,
                TableId = 19
            }
        };
        modelBuilder.Entity<Reservation>().HasData(reservations);
    }

    private static void SeedOrdersTable(ModelBuilder modelBuilder)
    {
        var orders = new Order[]
        {
            new Order()
            {
                OrderId = 1,
                EmployeeId = 1,
                OrderDate = new DateTime(2023, 10, 8, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5424),
                ReservationId = 1,
                TotalAmount = 99.99
            },
            new Order()
            {
                OrderId = 2,
                EmployeeId = 1,
                OrderDate = new DateTime(2023, 10, 7, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5449),
                ReservationId = 2,
                TotalAmount = 81.69
            },
            new Order()
            {
                OrderId = 3,
                EmployeeId = 1,
                OrderDate = new DateTime(2023, 10, 6, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5460),
                ReservationId = 3,
                TotalAmount = 217.96
            },
            new Order()
            {
                OrderId = 4,
                EmployeeId = 1,
                OrderDate = new DateTime(2023, 10, 5, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5484),
                ReservationId = 4,
                TotalAmount = 174.75
            },
            new Order()
            {
                OrderId = 5,
                EmployeeId = 1,
                OrderDate = new DateTime(2023, 10, 4, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5502),
                ReservationId = 5,
                TotalAmount = 98.22
            },
            new Order()
            {
                OrderId = 6,
                EmployeeId = 1,
                OrderDate = new DateTime(2023, 10, 3, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5512),
                ReservationId = 6,
                TotalAmount = 49.75
            },
            new Order()
            {
                OrderId = 7,
                EmployeeId = 1,
                OrderDate = new DateTime(2023, 10, 2, 11, 1, 50, 514, DateTimeKind.Local).AddTicks(5521),
                ReservationId = 7,
                TotalAmount = 64.48
            }
        };
        modelBuilder.Entity<Order>().HasData(orders);
    }

    private static void SeedOrderItemsTable(ModelBuilder modelBuilder)
    {
        var orderItems = new OrderItem[]
        {
            new OrderItem()
            {
                OrderItemId = 1,
                MenuItemId = 2,
                OrderId = 1,
                Quantity = 4
            },
            new OrderItem
            {
                OrderItemId = 2,
                MenuItemId = 4,
                OrderId = 1,
                Quantity = 1
            },
            new OrderItem
            {
                OrderItemId = 3,
                MenuItemId = 1,
                OrderId = 2,
                Quantity = 2
            },
            new OrderItem
            {
                OrderItemId = 4,
                MenuItemId = 4,
                OrderId = 2,
                Quantity = 2
            },
            new OrderItem
            {
                OrderItemId = 5,
                MenuItemId = 4,
                OrderId = 2,
                Quantity = 2
            },
            new OrderItem
            {
                OrderItemId = 6,
                MenuItemId = 3,
                OrderId = 2,
                Quantity = 1
            },
            new OrderItem
            {
                OrderItemId = 7,
                MenuItemId = 8,
                OrderId = 3,
                Quantity = 4
            },
            new OrderItem
            {
                OrderItemId = 8,
                MenuItemId = 7,
                OrderId = 3,
                Quantity = 4
            },
            new OrderItem
            {
                OrderItemId = 9,
                MenuItemId = 7,
                OrderId = 3,
                Quantity = 4
            },
            new OrderItem
            {
                OrderItemId = 10,
                MenuItemId = 7,
                OrderId = 4,
                Quantity = 1
            },
            new OrderItem
            {
                OrderItemId = 11,
                MenuItemId = 6,
                OrderId = 4,
                Quantity = 3
            },
            new OrderItem
            {
                OrderItemId = 12,
                MenuItemId = 7,
                OrderId = 4,
                Quantity = 2
            },
            new OrderItem
            {
                OrderItemId = 13,
                MenuItemId = 7,
                OrderId = 4,
                Quantity = 4
            },
            new OrderItem
            {
                OrderItemId = 14,
                MenuItemId = 10,
                OrderId = 5,
                Quantity = 3
            },
            new OrderItem
            {
                OrderItemId = 15,
                MenuItemId = 12,
                OrderId = 5,
                Quantity = 1
            },
            new OrderItem
            {
                OrderItemId = 16,
                MenuItemId = 11,
                OrderId = 5,
                Quantity = 4
            },
            new OrderItem
            {
                OrderItemId = 17,
                MenuItemId = 16,
                OrderId = 6,
                Quantity = 1
            },
            new OrderItem
            {
                OrderItemId = 18,
                MenuItemId = 15,
                OrderId = 6,
                Quantity = 4
            },
            new OrderItem
            {
                OrderItemId = 19,
                MenuItemId = 17,
                OrderId = 7,
                Quantity = 2
            },
            new OrderItem
            {
                OrderItemId = 20,
                MenuItemId = 17,
                OrderId = 7,
                Quantity = 1
            },
            new OrderItem
            {
                OrderItemId = 21,
                MenuItemId = 19,
                OrderId = 7,
                Quantity = 2
            }
        };

        modelBuilder.Entity<OrderItem>().HasData(orderItems);
    }
}