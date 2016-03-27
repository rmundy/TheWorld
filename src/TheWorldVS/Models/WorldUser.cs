using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace TheWorldVS.Models
{
    public class WorldUser : IdentityUser
    {
        public DateTime FirstTrip { get; set; }
    }
}