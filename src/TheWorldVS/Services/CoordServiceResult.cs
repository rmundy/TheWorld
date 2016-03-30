namespace TheWorldVS.Services
{
    public class CoordServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public double Longitude { get; internal set; }
        public double Latitude { get; internal set; }
    }
}