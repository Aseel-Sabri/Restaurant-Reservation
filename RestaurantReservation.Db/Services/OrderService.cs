using FluentResults;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMenuItemRepository _menuItemRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public OrderService(IOrderRepository orderRepository, IMenuItemRepository menuItemRepository,
        IReservationRepository reservationRepository, IEmployeeRepository employeeRepository)
    {
        _orderRepository = orderRepository;
        _menuItemRepository = menuItemRepository;
        _reservationRepository = reservationRepository;
        _employeeRepository = employeeRepository;
    }

    public Result<int> CreateOrder(OrderDto orderDto)
    {
        if (orderDto.HasAnyNullOrEmptyFields())
            return Result.Fail($"All Order Fields Must Be Provided");

        if (!_employeeRepository.HasEmployeeById((int)orderDto.EmployeeId!))
            return Result.Fail($"No Employee With ID {orderDto.EmployeeId} Exists");

        if (!_reservationRepository.HasReservationById((int)orderDto.ReservationId!))
            return Result.Fail($"No Reservation With ID {orderDto.ReservationId} Exists");

        // Should I check if both employee and reservation belong to the same restaurant? 

        var order = new Order()
        {
            EmployeeId = (int)orderDto.EmployeeId,
            ReservationId = (int)orderDto.ReservationId,
            OrderDate = (DateTime)orderDto.OrderDate!,
        };

        var orderId = _orderRepository.CreateOrder(order);
        return Result.Ok(orderId);
    }

    public Result<OrderDto> UpdateOrder(OrderDto orderDto)
    {
        var order = _orderRepository.FindOrderById(orderDto.OrderId);
        if (order is null)
            return Result.Fail($"No Order with ID {orderDto.OrderId} Exists");

        if (orderDto.ReservationId is not null)
        {
            if (!_reservationRepository.HasReservationById((int)orderDto.ReservationId))
                return Result.Fail($"No Reservation with ID {orderDto.ReservationId} Exists");

            order.ReservationId = (int)orderDto.ReservationId;
        }

        if (orderDto.EmployeeId is not null)
        {
            if (!_employeeRepository.HasEmployeeById((int)orderDto.EmployeeId))
                return Result.Fail($"No Employee with ID {orderDto.EmployeeId} Exists");

            order.EmployeeId = (int)orderDto.EmployeeId;
        }

        order.OrderDate = orderDto.OrderDate ?? order.OrderDate;

        var updatedOrder = _orderRepository.UpdateOrder(order);
        return Result.Ok(MapToOrderDto(updatedOrder));
    }

    public Result DeleteOrder(int orderId)
    {
        if (!_orderRepository.HasOrderById(orderId))
            return Result.Fail($"No Order With ID {orderId} Exists");

        var errorMessage = $"Could Not Delete Order With ID {orderId}";
        try
        {
            return Result.OkIf(_orderRepository.DeleteOrder(orderId), errorMessage);
        }
        catch (Exception e)
        {
            return Result.Fail(errorMessage);
        }
    }

    public Result<List<OrdersAndMenuItemsDto>> ListOrdersAndMenuItems(int reservationId)
    {
        if (!_reservationRepository.HasReservationById(reservationId))
            return Result.Fail($"No Reservation With ID {reservationId} Exists");

        return _orderRepository.ListOrdersAndMenuItems(reservationId);
    }

    public Result<int> CreateOrderItem(OrderItemDto orderItemDto)
    {
        var menuItem = _menuItemRepository.FindItemById(orderItemDto.MenuItemId);
        if (menuItem is null)
            return Result.Fail($"No Menu Item With ID {orderItemDto.MenuItemId} Exists");

        var order = _orderRepository.FindOrderById(orderItemDto.OrderId);
        if (order is null)
            return Result.Fail($"No Order With ID {orderItemDto.OrderId} Exists");


        var orderItem = new OrderItem()
        {
            Order = order,
            MenuItemId = orderItemDto.MenuItemId,
            Quantity = orderItemDto.Quantity
        };

        order.TotalAmount += menuItem.Price * orderItem.Quantity;

        var itemId = _orderRepository.CreateOrderItem(orderItem);
        return Result.Ok(itemId);
    }

    public Result<OrderItemDto> UpdateOrderItemQuantity(int orderItemId, int quantity)
    {
        var orderItem = _orderRepository.FindOrderItemById(orderItemId);
        if (orderItem is null)
            return Result.Fail($"No OrderItem with ID {orderItemId} Exists");

        orderItem.Order = _orderRepository.FindOrderById(orderItem.OrderId)!;
        orderItem.Item = _menuItemRepository.FindItemById(orderItem.MenuItemId)!;

        orderItem.Order.TotalAmount = quantity * orderItem.Item.Price;
        orderItem.Quantity = quantity;


        var updatedOrderItem = _orderRepository.UpdateOrderItem(orderItem);
        return Result.Ok(MapToOrderItemDto(updatedOrderItem));
    }

    public Result DeleteOrderItem(int orderItemId)
    {
        var orderItem = _orderRepository.FindOrderItemById(orderItemId);

        if (orderItem is null)
            return Result.Fail($"No Order Item With ID {orderItemId} Exists");

        orderItem.Order = _orderRepository.FindOrderById(orderItem.OrderId)!;
        orderItem.Item = _menuItemRepository.FindItemById(orderItem.MenuItemId)!;

        orderItem.Order.TotalAmount -= orderItem.Quantity * orderItem.Item.Price;

        return Result.OkIf(_orderRepository.DeleteOrderItem(orderItemId),
            $"Could Not Delete Order Item With ID {orderItemId}");
    }

    private OrderItemDto MapToOrderItemDto(OrderItem orderItem)
    {
        return new OrderItemDto()
        {
            OrderItemId = orderItem.OrderItemId,
            OrderId = orderItem.OrderId,
            MenuItemId = orderItem.MenuItemId,
            Quantity = orderItem.Quantity
        };
    }

    private OrderDto MapToOrderDto(Order order)
    {
        return new OrderDto()
        {
            OrderId = order.OrderId,
            EmployeeId = order.EmployeeId,
            ReservationId = order.ReservationId,
            OrderDate = order.OrderDate
        };
    }
}