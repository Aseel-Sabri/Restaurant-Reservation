﻿using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public interface IReservationRepository
{
    int CreateReservation(Reservation reservation);
    Reservation UpdateReservation(Reservation reservation);
    bool DeleteReservation(int reservationId);
    Reservation? FindReservationById(int reservationId);
    bool HasReservationById(int reservationId);
}