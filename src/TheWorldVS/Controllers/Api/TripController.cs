namespace TheWorldVS.Controllers.Api
{
    using Microsoft.AspNet.Mvc;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TripController : Controller
    {
        public TripController(IWorldRepository repository)
        {
            this.Repository = repository;
        }

        public IWorldRepository Repository { get; private set; }

        [HttpGet("api/trips")]
        public JsonResult Get()
        {
            var results = this.Repository.GetAllTripsWithStops();
            return Json(results);
        }
    }
}
