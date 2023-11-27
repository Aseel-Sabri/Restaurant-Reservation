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

    public async Task CreateOrder()
    {
        var orderDto = new OrderDto()
        {
            EmployeeId = 1,
            OrderDate = DateTime.Today,
            ReservationId = 2
        };

        var result = await _orderService.CreateOrder(orderDto);
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

    public async Task UpdateOrder()
    {
        var orderDto = new OrderDto()
        {
            OrderId = 2,
            EmployeeId = 2
        };

        var result = await _orderService.UpdateOrder(orderDto);
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

    public async Task DeleteOrder(int orderId)
    {
        var result = await _orderService.DeleteOrder(orderId);

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

    public async Task ListOrdersAndMenuItems(int reservationId)
    {
        var result = await _orderService.ListOrdersAndMenuItems(reservationId);
        if (result.IsFailed)
        {
            result.Errors.ForEach(error => Console.WriteLine(error.Message));
            return;
        }

        var orders = result.Value;

        orders.ForEach(order =>
        {
            Console.WriteLine(
                $"""
                 OrderId: {order.OrderId}
                 OrderDate: {order.OrderDate}
                 EmployeeId: {order.EmployeeId}
                 TotalAmount: {order.TotalAmount}
                 MenuItems:
                 """
            );

            order.MenuItems.ForEach(item => Console.WriteLine(
                $"""
                     ItemId: {item.ItemId}
                     Name: {item.Name}
                     Description: {item.Description}
                     RestaurantId: {item.RestaurantId}
                     
                 """
            ));
        });
    }

    public async Task CreateOrderItem()
    {
        var orderItemDto = new OrderItemDto()
        {
            OrderId = 9,
            Quantity = 2,
            MenuItemId = 1
        };

        var result = await _orderService.CreateOrderItem(orderItemDto);
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

    public async Task UpdateOrderItemQuantity()
    {
        var result = await _orderService.UpdateOrderItemQuantity(26, 1);
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

    public async Task DeleteOrderItem(int orderId)
    {
        var result = await _orderService.DeleteOrderItem(orderId);

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