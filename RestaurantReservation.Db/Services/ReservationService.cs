using FluentResults;
using RestaurantReservation.Db.DTOs;
using RestaurantReservation.Db.KeylessEntities;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly ITableRepository _tableRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IRestaurantRepository _restaurantRepository;

    public ReservationService(IReservationRepository reservationRepository, ITableRepository tableRepository,
        ICustomerRepository customerRepository, IRestaurantRepository restaurantRepository)
    {
        _reservationRepository = reservationRepository;
        _tableRepository = tableRepository;
        _customerRepository = customerRepository;
        _restaurantRepository = restaurantRepository;
    }

    public async Task<Result<int>> CreateReservation(ReservationDto reservationDto)
    {
        if (reservationDto.HasAnyNullOrEmptyFields())
            return Result.Fail($"All Reservation Fields Must Be Provided");

        if (!await _restaurantRepository.HasRestaurantById((int)reservationDto.RestaurantId!))
            return Result.Fail($"No Restaurant With ID {reservationDto.RestaurantId} Exists");

        var table = await _tableRepository.FindTableById((int)reservationDto.TableId!);
        if (table is null)
            return Result.Fail($"No Table With ID {reservationDto.TableId} Exists");

        if (table.RestaurantId != reservationDto.RestaurantId)
            return Result.Fail(
                $"Table With ID {reservationDto.TableId} Does Not Belong To Restaurant With ID {reservationDto.RestaurantId}");

        if (!await _customerRepository.HasCustomerById((int)reservationDto.CustomerId!))
            return Result.Fail($"No Customer With ID {reservationDto.CustomerId} Exists");

        var reservation = new Reservation()
        {
            RestaurantId = (int)reservationDto.RestaurantId!,
            CustomerId = (int)reservationDto.CustomerId!,
            TableId = (int)reservationDto.TableId!,
            PartySize = (int)reservationDto.PartySize!,
            ReservationDate = (DateTime)reservationDto.ReservationDate!
        };

        var reservationId = await _reservationRepository.CreateReservation(reservation);
        return Result.Ok(reservationId);
    }

    public async Task<Result<ReservationDto>> UpdateReservation(ReservationDto reservationDto)
    {
        var reservation = await _reservationRepository.FindReservationById(reservationDto.ReservationId);
        if (reservation is null)
            return Result.Fail($"No Reservation With ID {reservationDto.ReservationId} Exists");

        reservation.PartySize = reservationDto.PartySize ?? reservation.PartySize;
        reservation.ReservationDate = reservationDto.ReservationDate ?? reservation.ReservationDate;


        if (reservationDto.TableId is not null)
        {
            var table = await _tableRepository.FindTableById((int)reservationDto.TableId!);
            if (table is null)
                return Result.Fail($"No Table With ID {reservationDto.TableId} Exists");

            if (table.RestaurantId != reservationDto.RestaurantId)
                return Result.Fail(
                    $"Table With ID {reservationDto.TableId} Does Not Belong To Restaurant With ID {reservation.RestaurantId}");

            reservation.TableId = (int)reservationDto.TableId;
        }

        if (reservationDto.CustomerId is not null)
        {
            if (!await _customerRepository.HasCustomerById((int)reservationDto.CustomerId!))
                return Result.Fail($"No Customer With ID {reservationDto.CustomerId} Exists");

            reservation.CustomerId = (int)reservationDto.CustomerId;
        }


        var updatedReservation = await _reservationRepository.UpdateReservation(reservation);
        return Result.Ok(MapToReservationDto(updatedReservation));
    }

    public async Task<Result> DeleteReservation(int reservationId)
    {
        if (!await _reservationRepository.HasReservationById(reservationId))
            return Result.Fail($"No Reservation With ID {reservationId} Exists");


        var errorMessage = $"Could Not Delete Reservation With ID {reservationId}";
        try
        {
            return Result.OkIf(await _reservationRepository.DeleteReservation(reservationId),
                errorMessage);
        }
        catch (Exception e)
        {
            return Result.Fail(errorMessage);
        }
    }

    public async Task<Result<List<ReservationDto>>> GetReservationsByCustomer(int customerId)
    {
        if (!await _customerRepository.HasCustomerById(customerId))
            return Result.Fail($"No Customer With ID {customerId} Exists");

        return (await _reservationRepository.GetReservationsByCustomer(customerId))
            .Select(MapToReservationDto)
            .ToList();
    }

    public async Task<List<ReservationDetails>> GetReservationsWithCustomerAndRestaurantDetails()
    {
        return await _reservationRepository.GetReservationsWithCustomerAndRestaurantDetails();
    }

    private ReservationDto MapToReservationDto(Reservation reservation)
    {
        return new ReservationDto()
        {
            RestaurantId = reservation.RestaurantId,
            PartySize = reservation.PartySize,
            ReservationDate = reservation.ReservationDate,
            CustomerId = reservation.CustomerId,
            ReservationId = reservation.ReservationId,
            TableId = reservation.TableId
        };
    }
}