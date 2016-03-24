using System;
using System.ComponentModel.DataAnnotations;

namespace TheWorldVS.ViewModels
{
    public class TripViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public String Name { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}