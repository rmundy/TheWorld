using System;
using System.Collections.Generic;

namespace TheWorldVS.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetAllTripsWithStops();
        void AddTrip(Trip newTrip);
        Boolean SaveAll();
        Trip GetTripByName(String tripName);
        void AddStop(Stop newStop, String tripName);
    }
}