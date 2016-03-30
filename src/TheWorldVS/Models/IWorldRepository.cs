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
        Trip GetTripByName(String tripName, string userName);
        void AddStop(Stop newStop, String tripName, String userName);
        IEnumerable<Trip> GetUserTripsWithStops(string name);
    }
}