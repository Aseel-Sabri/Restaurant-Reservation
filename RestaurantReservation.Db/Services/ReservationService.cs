using AutoMapper;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.Exceptions;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.ValueObjects;

namespace RestaurantReservation.Db.Services;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly ITableRepository _tableRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IMapper _mapper;

    public ReservationService(IReservationRepository reservationRepository, ITableRepository tableRepository,
        ICustomerRepository customerRepository, IRestaurantRepository restaurantRepository, IMapper mapper)
    {
        _reservationRepository = reservationRepository;
        _tableRepository = tableRepository;
        _customerRepository = customerRepository;
        _restaurantRepository = restaurantRepository;
        _mapper = mapper;
    }

    public async Task<int> CreateReservation(ModifyReservationDto reservationDto)
    {
        if (!await _restaurantRepository.HasRestaurantById((int)reservationDto.RestaurantId!))
            throw new NotFoundException($"No Restaurant With ID {reservationDto.RestaurantId} Exists");

        var table = await _tableRepository.FindTableById((int)reservationDto.TableId!);
        if (table is null)
            throw new NotFoundException($"No Table With ID {reservationDto.TableId} Exists");

        if (table.RestaurantId != reservationDto.RestaurantId)
            throw new ApiException(
                $"Table With ID {reservationDto.TableId} Does Not Belong To Restaurant With ID {reservationDto.RestaurantId}");

        if (!await _customerRepository.HasCustomerById((int)reservationDto.CustomerId!))
            throw new NotFoundException($"No Customer With ID {reservationDto.CustomerId} Exists");

        var reservation = _mapper.Map<Reservation>(reservationDto);

        var reservationId = await _reservationRepository.CreateReservation(reservation);
        return reservationId;
    }

    public async Task<ReservationDto> UpdateReservation(int reservationId, ModifyReservationDto reservationDto)
    {
        var reservation = await _reservationRepository.FindReservationById(reservationId);
        if (reservation is null)
            throw new NotFoundException($"No Reservation With ID {reservationId} Exists");

        var table = await _tableRepository.FindTableById((int)reservationDto.TableId!);
        if (table is null)
            throw new NotFoundException($"No Table With ID {reservationDto.TableId} Exists");

        if (table.RestaurantId != reservationDto.RestaurantId)
            throw new ApiException(
                $"Table With ID {reservationDto.TableId} Does Not Belong To Restaurant With ID {reservation.RestaurantId}");

        if (!await _customerRepository.HasCustomerById((int)reservationDto.CustomerId!))
            throw new NotFoundException($"No Customer With ID {reservationDto.CustomerId} Exists");

        _mapper.Map(reservationDto, reservation);

        var updatedReservation = await _reservationRepository.UpdateReservation(reservation);
        return _mapper.Map<ReservationDto>(updatedReservation);
    }

    public async Task DeleteReservation(int reservationId)
    {
        if (!await _reservationRepository.HasReservationById(reservationId))
            throw new NotFoundException($"No Reservation With ID {reservationId} Exists");

        if (await _reservationRepository.DeleteReservation(reservationId))
            throw new ApiException($"Could Not Delete Reservation With ID {reservationId}");
    }

    public async Task<IEnumerable<ReservationDto>> GetReservationsByCustomer(int customerId)
    {
        if (!await _customerRepository.HasCustomerById(customerId))
            throw new NotFoundException($"No Customer With ID {customerId} Exists");

        var reservations = await _reservationRepository.GetReservationsByCustomer(customerId);
        return _mapper.Map<IEnumerable<ReservationDto>>(reservations);
    }

    public async Task<IEnumerable<ReservationDetails>> GetReservationsWithCustomerAndRestaurantDetails()
    {
        return await _reservationRepository.GetReservationsWithCustomerAndRestaurantDetails();
    }

    public async Task<IEnumerable<ReservationDto>> GetAllReservations()
    {
        var reservations = await _reservationRepository.GetAllReservations();
        return _mapper.Map<IEnumerable<ReservationDto>>(reservations);
    }

    public async Task<ReservationDto> FindReservationById(int reservationId)
    {
        var reservation = await _reservationRepository.FindReservationById(reservationId);
        if (reservation is null)
            throw new NotFoundException($"No Reservation With ID {reservationId} Exists");

        return _mapper.Map<ReservationDto>(reservation);
    }
}