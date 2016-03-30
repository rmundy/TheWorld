using System;
using System.ComponentModel.DataAnnotations;

namespace TheWorldVS.ViewModels
{
    public sealed class StopViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public String Name { get; set; }

        public Double Longitude { get; set; }
        public Double Latitude { get; set; }

        [Required]
        public DateTime Arrival { get; set; }
    }
}