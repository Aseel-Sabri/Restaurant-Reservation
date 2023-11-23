using AutoMapper;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Exceptions;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.ValueObjects;

namespace RestaurantReservation.Db.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMenuItemRepository _menuItemRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMenuItemRepository menuItemRepository,
        IReservationRepository reservationRepository, IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _menuItemRepository = menuItemRepository;
        _reservationRepository = reservationRepository;
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<int> CreateOrder(ModifyOrderDto orderDto)
    {
        if (!await _employeeRepository.HasEmployeeById((int)orderDto.EmployeeId!))
            throw new NotFoundException($"No Employee With ID {orderDto.EmployeeId} Exists");

        if (!await _reservationRepository.HasReservationById((int)orderDto.ReservationId!))
            throw new NotFoundException($"No Reservation With ID {orderDto.ReservationId} Exists");

        // Should I check if both employee and reservation belong to the same restaurant? 

        var order = _mapper.Map<Order>(orderDto);
        order.OrderDate = DateTime.Now;

        var orderId = await _orderRepository.CreateOrder(order);
        return orderId;
    }

    public async Task<OrderDto> UpdateOrder(int orderId, ModifyOrderDto orderDto)
    {
        var order = await _orderRepository.FindOrderById(orderId);
        if (order is null)
            throw new NotFoundException($"No Order with ID {orderId} Exists");

        if (!await _reservationRepository.HasReservationById((int)orderDto.ReservationId!))
            throw new NotFoundException($"No Reservation with ID {orderDto.ReservationId} Exists");

        if (!await _employeeRepository.HasEmployeeById((int)orderDto.EmployeeId!))
            throw new NotFoundException($"No Employee with ID {orderDto.EmployeeId} Exists");

        _mapper.Map(orderDto, order);

        var updatedOrder = await _orderRepository.UpdateOrder(order);
        return _mapper.Map<OrderDto>(updatedOrder);
    }

    public async Task DeleteOrder(int orderId)
    {
        if (!await _orderRepository.HasOrderById(orderId))
            throw new NotFoundException($"No Order With ID {orderId} Exists");

        if (!await _orderRepository.DeleteOrder(orderId))
            throw new ApiException($"Could Not Delete Order With ID {orderId} Exists");
    }

    public async Task<List<OrdersAndMenuItems>> ListOrdersAndMenuItems(int reservationId)
    {
        if (!await _reservationRepository.HasReservationById(reservationId))
            throw new NotFoundException($"No Reservation With ID {reservationId} Exists");

        return await _orderRepository.ListOrdersAndMenuItems(reservationId);
    }

    public async Task<int> CreateOrderItem(int orderId, CreateOrderItemDto orderItemDto)
    {
        if (!await _orderRepository.HasOrderById(orderId))
            throw new NotFoundException($"No Order With ID {orderId} Exists");

        if (!await _menuItemRepository.HasItemById((int)orderItemDto.MenuItemId))
            throw new NotFoundException($"No Menu Item With ID {orderItemDto.MenuItemId} Exists");

        var orderItem = _mapper.Map<OrderItem>(orderItemDto);
        orderItem.OrderId = orderId;

        var itemId = await _orderRepository.CreateOrderItem(orderItem);
        return itemId;
    }

    public async Task<OrderItemDto> UpdateOrderItem(int orderId, int orderItemId, UpdateOrderItemDto orderItemDto)
    {
        if (!await _orderRepository.HasOrderItemById(orderId, orderItemId))
            throw new NotFoundException($"No OrderItem with ID {orderItemId} Exists For Order {orderId}");

        var orderItem = await _orderRepository.FindOrderItemById(orderItemId);

        _mapper.Map(orderItemDto, orderItem);
        var updatedOrderItem = await _orderRepository.UpdateOrderItem(orderItem!);
        return _mapper.Map<OrderItemDto>(updatedOrderItem);
    }

    public async Task DeleteOrderItem(int orderId, int orderItemId)
    {
        if (!await _orderRepository.HasOrderItemById(orderId, orderItemId))
            throw new NotFoundException($"No OrderItem with ID {orderItemId} Exists For Order {orderId}");

        if (!await _orderRepository.DeleteOrderItem(orderItemId))
            throw new ApiException($"Could Not Delete Order Item With ID {orderItemId}");
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrders()
    {
        var orders = await _orderRepository.GetAllOrders();
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<IEnumerable<OrderItemDto>> GetOrderItems(int orderId)
    {
        var orderItems = await _orderRepository.GetOrderItems(orderId);
        return _mapper.Map<IEnumerable<OrderItemDto>>(orderItems);
    }

    public async Task<OrderDto> FindOrderById(int orderId)
    {
        var order = await _orderRepository.FindOrderById(orderId);
        if (order is null)
            throw new NotFoundException($"No Order With ID {orderId} Exists");

        return _mapper.Map<OrderDto>(order);
    }

    public async Task<OrderItemDto> FindOrderItemById(int orderId, int orderItemId)
    {
        if (!await _orderRepository.HasOrderItemById(orderId, orderItemId))
            throw new NotFoundException($"No OrderItem with ID {orderItemId} Exists For Order {orderId}");

        var orderItem = await _orderRepository.FindOrderItemById(orderItemId);

        return _mapper.Map<OrderItemDto>(orderItem);
    }
}