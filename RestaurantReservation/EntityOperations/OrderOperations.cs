using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Services;

namespace RestaurantReservation.EntityOperations;

public class OrderOperations
{
    private readonly IOrderService _orderService;

    public OrderOperations(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public void CreateOrder()
    {
        var orderDto = new OrderDto()
        {
            EmployeeId = 1,
            OrderDate = DateTime.Today,
            ReservationId = 2
        };

        var result = _orderService.CreateOrder(orderDto);
        if (result.IsSuccess)
        {
            var createdOrderId = result.Value;
            Console.WriteLine($"Order Added With ID {createdOrderId}");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public void UpdateOrder()
    {
        var orderDto = new OrderDto()
        {
            OrderId = 2,
            EmployeeId = 2
        };

        var result = _orderService.UpdateOrder(orderDto);
        if (result.IsSuccess)
        {
            Console.WriteLine($"Updated Order: {Environment.NewLine}{result.Value}");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public void DeleteOrder(int orderId)
    {
        var result = _orderService.DeleteOrder(orderId);

        if (result.IsSuccess)
        {
            Console.WriteLine($"Order With ID {orderId} Deleted Successfully");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public void CreateOrderItem()
    {
        var orderItemDto = new OrderItemDto()
        {
            OrderId = 9,
            Quantity = 2,
            MenuItemId = 1
        };

        var result = _orderService.CreateOrderItem(orderItemDto);
        if (result.IsSuccess)
        {
            var createdOrderId = result.Value;
            Console.WriteLine($"Order Item Added With ID {createdOrderId}");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public void UpdateOrderItemQuantity()
    {
        var result = _orderService.UpdateOrderItemQuantity(26, 1);
        if (result.IsSuccess)
        {
            Console.WriteLine($"Updated Order Item: {Environment.NewLine}{result.Value}");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }

    public void DeleteOrderItem(int orderId)
    {
        var result = _orderService.DeleteOrderItem(orderId);

        if (result.IsSuccess)
        {
            Console.WriteLine($"Order Item With ID {orderId} Deleted Successfully");
        }
        else
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
        }

        Console.WriteLine();
    }
}