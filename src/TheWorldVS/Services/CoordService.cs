using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TheWorldVS.Services
{
    public class CoordService
    {
        public CoordService(ILogger<CoordService> logger)
        {
            this.Logger = logger;
        }

        public ILogger<CoordService> Logger { get; private set; }

        public CoordServiceResult Lookup(String location)
        {
            var result = new CoordServiceResult()
            {
                Success = false,
                Message = "Undetermined failure while looking up coordinates"
            };

            // Lookup Coordinates
            var encodedName = WebUtility.UrlEncode(location);
            var bingKey = Startup.Configuration["AppSettings:BingKey"];
            var url = $"http://dev.virtualearth.net/REST/v1/Locations?q={encodedName}&key={bingKey}";

            return result;
        }
    }
}
