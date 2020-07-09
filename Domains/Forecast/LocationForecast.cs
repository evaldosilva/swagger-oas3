namespace swagger_oas3.Domains.Forecast
{
    public class LocationForecast
    {
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }

        public LocationForecast(decimal Latitude, decimal Longitude)
        {
            this.Longitude = Longitude;
            this.Latitude = Latitude;
        }
    }
}