namespace TheWorldVS.Models
{
    using System;

    public class Stop
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Double Longitude { get; set; }
        public Double Latitude { get; set; }
        public DateTime Arrival { get; set; }
        public Int32 Order { get; set; }
    }
}