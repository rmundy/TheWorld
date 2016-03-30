namespace TheWorldVS.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Trip
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public DateTime Created { get; set; }
        public String UserName { get; set; }

        public ICollection<Stop> Stops { get; set; }
    }
}
