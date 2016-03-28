using AutoMapper;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TheWorldVS.ViewModels;
using TheWorldVS.Models;
using TheWorldVS.Services;

namespace TheWorldVS.Controllers.Api
{
    [Route("api/trips/{tripName}/stops")]
    public class StopController : Controller
    {
        public StopController(IWorldRepository repository, 
            ILogger<StopController> logger,
            CoordService coordService)
        {
            this.Repository = repository;
            this.Logger = logger;
            this.CoordService = coordService;

        }

        public CoordService CoordService { get; private set; }
        public ILogger Logger { get; private set; }
        public IWorldRepository Repository { get; private set; }

        [HttpGet("")]
        public JsonResult Get(String tripName)
        {
            try
            {
                var results = this.Repository.GetTripByName(tripName);
                if(results == null)
                {
                    return Json(null);
                }

                return Json(Mapper.Map<IEnumerable<StopViewModel>>(results.Stops.OrderBy(s => s.Order)));
                
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"Failed to get stops for trip {tripName}", ex);
                Response.StatusCode = (Int32)HttpStatusCode.BadRequest;
                return Json("Error occurred finding trip name");
            }
        }

        [HttpPost("")]
        public async Task<JsonResult> Post(String tripName, [FromBody]StopViewModel vm)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    // Map to the entity
                    var newStop = Mapper.Map<Stop>(vm);

                    // Looking up Geocoordinates
                    var coordResult = await this.CoordService.Lookup(newStop.Name);
                    if(!coordResult.Success)
                    {
                        Response.StatusCode = (Int32)HttpStatusCode.BadRequest;
                        return Json(coordResult.Message);
                    }

                    newStop.Longitude = coordResult.Longitude;
                    newStop.Latitude = coordResult.Latitude;

                    // Save to the database
                    this.Repository.AddStop(newStop, tripName);
                    if(this.Repository.SaveAll())
                    {
                        Response.StatusCode = (Int32)HttpStatusCode.Created;
                        return Json(Mapper.Map<StopViewModel>(newStop));
                    }
                    else
                    {
                        return Json(null);
                    }

                }
                else
                {
                    return Json(null);
                }
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"Failed to save new stop for trip {tripName}", ex);
                Response.StatusCode = (Int32)HttpStatusCode.BadRequest;
                return Json("Error saving stops.");
            }
        }
    }
}
