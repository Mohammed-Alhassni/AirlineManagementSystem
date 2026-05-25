namespace AirlineManagementSystem.Models;

public class Airport
{
    public string IataCode { get; set; }
    public string FullName { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public int TimeZoneOffset { get; set; }
}