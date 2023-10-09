using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db;

public static class DataSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        SeedCustomersTable(modelBuilder);
        SeedRestaurantsTable(modelBuilder);
        SeedTablesTable(modelBuilder);
        SeedEmployeesTable(modelBuilder);
        SeedReservationsTable(modelBuilder);
        var menuItems = SeedMenuItemsTable(modelBuilder);
        SeedOrdersAndOrderItemsTables(modelBuilder, menuItems);
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
        var tables = new List<Table>();

        int numOfTables = 20, reservationsPerRestaurant = 4;
        var random = new Random();
        int minCapacity = 2, maxCapacity = 10;

        for (int i = 0; i < numOfTables; i++)
        {
            tables.Add(new Table
            {
                TableId = i + 1,
                RestaurantId = (i / reservationsPerRestaurant) + 1,
                Capacity = random.Next(minCapacity, maxCapacity + 1)
            });
        }

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

    private static List<MenuItem> SeedMenuItemsTable(ModelBuilder modelBuilder)
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
        return menuItems;
    }

    private static void SeedReservationsTable(ModelBuilder modelBuilder)
    {
        var reservations = new List<Reservation>
        {
            new Reservation
            {
                ReservationId = 1,
                CustomerId = 1,
                RestaurantId = 1,
                TableId = 1,
                ReservationDate = DateTime.Now.AddDays(1),
                PartySize = 4
            },
            new Reservation
            {
                ReservationId = 2,
                CustomerId = 1,
                RestaurantId = 1,
                TableId = 2,
                ReservationDate = DateTime.Now.AddDays(2),
                PartySize = 2
            },
            new Reservation
            {
                ReservationId = 3,
                CustomerId = 3,
                RestaurantId = 2,
                TableId = 5,
                ReservationDate = DateTime.Now.AddDays(3),
                PartySize = 6
            },
            new Reservation
            {
                ReservationId = 4,
                CustomerId = 4,
                RestaurantId = 2,
                TableId = 6,
                ReservationDate = DateTime.Now.AddDays(4),
                PartySize = 8
            },
            new Reservation
            {
                ReservationId = 5,
                CustomerId = 5,
                RestaurantId = 3,
                TableId = 9,
                ReservationDate = DateTime.Now.AddDays(5),
                PartySize = 3
            },
            new Reservation
            {
                ReservationId = 6,
                CustomerId = 5,
                RestaurantId = 4,
                TableId = 15,
                ReservationDate = DateTime.Now.AddDays(5),
                PartySize = 3
            },
            new Reservation
            {
                ReservationId = 7,
                CustomerId = 5,
                RestaurantId = 5,
                TableId = 19,
                ReservationDate = DateTime.Now.AddDays(5),
                PartySize = 3
            }
        };
        modelBuilder.Entity<Reservation>().HasData(reservations);
    }

    private static void SeedOrdersAndOrderItemsTables(ModelBuilder modelBuilder, List<MenuItem> menuItems)
    {
        var orderItemsMaxId = 0;
        var orders = new List<Order>
        {
            new Order()
            {
                OrderId = 1,
                ReservationId = 1,
                EmployeeId = 1,
                OrderDate = DateTime.Now.AddDays(-1),
                OrderItems = GenerateOrderItems(1, menuItems, ref orderItemsMaxId),
            },
            new Order()
            {
                OrderId = 2,
                ReservationId = 2,
                EmployeeId = 1,
                OrderDate = DateTime.Now.AddDays(-2),
                OrderItems = GenerateOrderItems(1, menuItems, ref orderItemsMaxId),
            },
            new Order()
            {
                OrderId = 3,
                ReservationId = 3,
                EmployeeId = 1,
                OrderDate = DateTime.Now.AddDays(-3),
                OrderItems = GenerateOrderItems(2, menuItems, ref orderItemsMaxId),
            },
            new Order()
            {
                OrderId = 4,
                ReservationId = 4,
                EmployeeId = 1,
                OrderDate = DateTime.Now.AddDays(-4),
                OrderItems = GenerateOrderItems(2, menuItems, ref orderItemsMaxId),
            },
            new Order()
            {
                OrderId = 5,
                ReservationId = 5,
                EmployeeId = 1,
                OrderDate = DateTime.Now.AddDays(-5),
                OrderItems = GenerateOrderItems(3, menuItems, ref orderItemsMaxId),
            },
            new Order()
            {
                OrderId = 6,
                ReservationId = 6,
                EmployeeId = 1,
                OrderDate = DateTime.Now.AddDays(-6),
                OrderItems = GenerateOrderItems(4, menuItems, ref orderItemsMaxId),
            },
            new Order()
            {
                OrderId = 7,
                ReservationId = 7,
                EmployeeId = 1,
                OrderDate = DateTime.Now.AddDays(-7),
                OrderItems = GenerateOrderItems(5, menuItems, ref orderItemsMaxId),
            }
        };

        var orderItems = new List<OrderItem>();

        orders.ForEach(order =>
        {
            order.TotalAmount = order.OrderItems.Sum(item => item.Quantity * item.Item.Price);
            order.OrderItems.ForEach(orderItem =>
            {
                orderItem.OrderId = order.OrderId;
                orderItem.Item = null; // Couldn't use 'HasData()' when the object was set, I have no idea why :\
            });
            orderItems.AddRange(order.OrderItems);
            order.OrderItems.Clear(); // Same here, I had to clear the list to be able to use 'HasData()'
        });

        modelBuilder.Entity<Order>().HasData(orders);
        modelBuilder.Entity<OrderItem>().HasData(orderItems);
    }

    private static List<OrderItem> GenerateOrderItems(int restaurantId, IReadOnlyList<MenuItem> menuItems,
        ref int orderItemsMaxId)
    {
        var orderItems = new List<OrderItem>();

        int maxNumOfItems = 5, maxQuantity = 4;
        var random = new Random();

        for (int i = 1; i <= random.Next(1, maxNumOfItems + 1); i++)
        {
            // the first 4 menu items belong to the first restaurant, the next 4 belong to the second one, and so on
            var menuItemIndex = random.Next((restaurantId - 1) * 4, restaurantId * 4);
            var orderItem = new OrderItem
            {
                OrderItemId = ++orderItemsMaxId,
                MenuItemId = menuItemIndex + 1,
                Item = menuItems[menuItemIndex],
                Quantity = random.Next(1, maxQuantity + 1)
            };

            orderItems.Add(orderItem);
        }

        return orderItems;
    }
}