namespace TheWorldVS.Controllers.Api
{
    using AutoMapper;
    using Microsoft.AspNet.Authorization;
    using Microsoft.AspNet.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using TheWorldVS.ViewModels;

    [Authorize]
    [Route("api/trips")]
    public class TripController : Controller
    {
        public TripController(IWorldRepository repository, ILogger<TripController> logger)
        {
            this.Repository = repository;
            this.Logger = logger;
        }

        public ILogger<TripController> Logger { get; private set; }
        public IWorldRepository Repository { get; private set; }

        [HttpGet("")]
        public JsonResult Get()
        {
            var trips = this.Repository.GetUserTripsWithStops(User.Identity.Name);
            var results = Mapper.Map<IEnumerable<TripViewModel>>(this.Repository.GetAllTripsWithStops());
            return Json(results);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]TripViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newTrip = Mapper.Map<Trip>(vm);

                    newTrip.UserName = User.Identity.Name;

                    // Save to the database
                    Logger.LogInformation("Attempting to save a new trip");
                    this.Repository.AddTrip(newTrip);
                    if(this.Repository.SaveAll())
                    {
                        Response.StatusCode = (Int32)HttpStatusCode.Created;
                        return Json(Mapper.Map<TripViewModel>(newTrip));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to save new trip", ex);
                Response.StatusCode = (Int32)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            Response.StatusCode = (Int32)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });

        }
    }
}
