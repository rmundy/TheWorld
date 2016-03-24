namespace TheWorldVS.Models
{
    using Microsoft.Data.Entity;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class WorldRepository : IWorldRepository
    {
        public WorldContext Context { get; private set; }
        public ILogger Logger { get; private set; }

        public WorldRepository(WorldContext context, ILogger<WorldRepository> logger)
        {
            this.Context = context;
            this.Logger = logger;
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            try
            {
                return this.Context.Trips.OrderBy(t => t.Name).ToList();
            }
            catch (Exception ex)
            {
                this.Logger.LogError("Could not get trips", ex);
                return null;
            }
        }

        public IEnumerable<Trip> GetAllTripsWithStops()
        {
            return this.Context.Trips
                .Include(t => t.Stops)
                .OrderBy(t => t.Name)
                .ToList();
        }
    }
}
