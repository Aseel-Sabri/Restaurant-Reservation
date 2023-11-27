using RestaurantReservation.EntityOperations;

namespace RestaurantReservation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppConfig.ConfigureServices();

            // var customerOperations = AppConfig.GetService<CustomerOperations>();
            // customerOperations.CreateCustomer();
            // customerOperations.UpdateCustomer();
            // customerOperations.DeleteCustomer(1);
            // customerOperations.FindCustomersWithPartySizeGreaterThan(3);

            // var employeeOperations = AppConfig.GetService<EmployeeOperations>();
            // employeeOperations.CreateEmployee();
            // employeeOperations.UpdateEmployee();
            // employeeOperations.DeleteEmployee(22);
            // employeeOperations.ListManagers();
            // employeeOperations.CalculateAverageOrderAmount(1);
            // employeeOperations.GetEmployeesDetails();

            // var restaurantOperations = AppConfig.GetService<RestaurantOperations>();
            // restaurantOperations.CreateRestaurant();
            // restaurantOperations.UpdateRestaurant();
            // restaurantOperations.DeleteRestaurant(6);
            // restaurantOperations.CalculateRestaurantTotalRevenue(2);

            // var tableOperations = AppConfig.GetService<TableOperations>();
            // tableOperations.CreateTable();
            // tableOperations.UpdateTableCapacity();
            // tableOperations.DeleteTable(21);

            // var reservationOperations = AppConfig.GetService<ReservationOperations>();
            // reservationOperations.CreateReservation();
            // reservationOperations.UpdateReservation();
            // reservationOperations.DeleteReservation(1);
            // reservationOperations.GetReservationsByCustomer(5);
            // reservationOperations.GetReservationsWithCustomerAndRestaurantDetails();

            // var orderOperations = AppConfig.GetService<OrderOperations>();
            // orderOperations.CreateOrder();
            // orderOperations.UpdateOrder();
            // orderOperations.DeleteOrder(8);
            // orderOperations.CreateOrderItem();
            // orderOperations.UpdateOrderItemQuantity();
            // orderOperations.DeleteOrderItem(26);
            // orderOperations.ListOrdersAndMenuItems(3);

            // var menuItemOperations = AppConfig.GetService<MenuItemOperations>();
            // menuItemOperations.CreateItem();
            // menuItemOperations.UpdateItem();
            // menuItemOperations.DeleteItem(1);
            // menuItemOperations.ListOrderedMenuItems(3);
        }
    }
}