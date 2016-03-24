namespace TheWorldVS.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public sealed class WorldContextSeedData
    {
        public WorldContext Context { get; private set; }
        public WorldContextSeedData(WorldContext context)
        {
            this.Context = context;
        }

        public void EnsureSeedData()
        {
            if(this.Context.Trips.Any())
            {
                // TODO: Add new data
            }
        }
    }
}
